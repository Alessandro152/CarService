using CarService.Models.ServiceStack.Entities;
using MySql.Data.MySqlClient;
using System;

namespace CarService.Models.Repository.Business
{
    public class BusinessRepository
    {
        private MySqlConnection DatabaseConnection { get; set; }

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

        private MySqlConnection ConectarBanco()
        {
            throw new NotImplementedException();
        }
    }
}
