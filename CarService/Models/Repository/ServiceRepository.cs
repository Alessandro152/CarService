
using CarService.Models.QueryStack.Interface;
using CarService.Models.ServiceStack.Entities;
using CarService.Models.ViewModels.Veiculo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Models.Repository
{
    public class ServiceRepository : IServiceRepository, IDisposable
    {
        private MySqlConnection connect;

        private MySqlConnection DatabaseConnection { get; set; }

        private MySqlDataReader Reader { get; set; }

        public Task<bool> RetornarOficinaCapacidadeMaxima(DateTime data)
        {
            try
            {
                MySqlCommand Comm;
                DatabaseConnection = ConectarBanco();

                Comm = DatabaseConnection.CreateCommand();

                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = $"SELECT COUNT(1) FROM SERVICO WHERE MANUTENCAO_DATA LIKE '%{data.Year}/{ data.Month}%'";

                var result = int.Parse(Comm.ExecuteScalar().ToString());

                return Task.FromResult(result != 10);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgendarManutencao(ManutencaoModel dados)
        {
            try
            {
                MySqlCommand Comm;
                DatabaseConnection = ConectarBanco();

                Comm = DatabaseConnection.CreateCommand();
                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL, TELEFONE) VALUES (@NOME, @EMAIL, @TELEFONE)";
                Comm.Parameters.AddWithValue("@NOME", dados.ClienteNome);
                Comm.Parameters.AddWithValue("@EMAIL", dados.ClienteEmail);
                Comm.Parameters.AddWithValue("@TELEFONE", dados.ClienteTelefone);
                Comm.ExecuteNonQuery();

                Comm.CommandText = "INSERT INTO VEICULO (VEICULO_MARCA, VEICULO_MODELO, VEICULO_ANO) VALUES (@VEICULO_MARCA, @VEICULO_MODELO, @VEICULO_ANO)";
                Comm.Parameters.AddWithValue("@VEICULO_MARCA", dados.ClienteVeiculoMarca);
                Comm.Parameters.AddWithValue("@VEICULO_MODELO", dados.ClienteVeiculoModelo);
                Comm.Parameters.AddWithValue("@VEICULO_ANO", dados.ClienteVeiculoAno);
                Comm.ExecuteNonQuery();

                Comm.CommandText = "INSERT INTO SERVICO (SERVICO_COMPLETO, SERVICO_MECANICA, SERVICO_SUSPENSAO, SERVICO_FREIO, MANUTENCAO_DATA) VALUES (@SERVICO_COMPLETO, @SERVICO_MECANICA, @SERVICO_SUSPENSAO, @SERVICO_FREIO, @MANUTENCAO_DATA)";
                Comm.Parameters.AddWithValue("@SERVICO_COMPLETO", dados.ClienteServicoCompleto);
                Comm.Parameters.AddWithValue("@SERVICO_MECANICA", dados.ClienteServicoMecanica);
                Comm.Parameters.AddWithValue("@SERVICO_SUSPENSAO", dados.ClienteServicoSuspensao);
                Comm.Parameters.AddWithValue("@SERVICO_FREIO", dados.ClienteServicoFreio);
                Comm.Parameters.AddWithValue("@MANUTENCAO_DATA", dados.DataManutencao);
                Comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<VeiculoViewModel> PopularMarca()
        {
            var items = new List<VeiculoViewModel>();

            try
            {
                MySqlCommand Comm;
                DatabaseConnection = ConectarBanco();

                Comm = DatabaseConnection.CreateCommand();

                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "SELECT TOP 1 FROM VEICULOS ORDER BY MARCA_NOME ASC";

                Reader = Comm.ExecuteReader();

                while (Reader.Read())
                {
                    items.Add(new VeiculoViewModel
                    {
                       Marca = Reader["MARCA_NOME"].ToString(),
                       Modelo = Reader["MODELO_NOME"].ToString(),
                       AnoVeiculo = Reader["ANO"].ToString()
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return items;
        }

        private MySqlConnection ConectarBanco()
        {
            string Connection = "server=localhost;uid=root;pwd=1234;";

            try
            {
                connect = new MySqlConnection();
                connect.ConnectionString = Connection;
                connect.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return connect;
        }

        public void Dispose()
        {
            DatabaseConnection.Dispose();
        }
    }
}