
using CarService.Models.QueryStack.Interface;
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

        private const int CAPACIDADE_MAXIMA_OFICINA = 10;

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

                return Task.FromResult(result < CAPACIDADE_MAXIMA_OFICINA);
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