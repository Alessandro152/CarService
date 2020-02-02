
using CarService.Models.QueryStack.Interface;
using CarService.Models.QueryStack.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CarService.Models.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private MySqlConnection connect;
        private MySqlConnection DatabaseConnection { get; set; }
        private MySqlDataReader Reader { get; set; }

        public int VerificarDataManutencao(DateTime data)
        {
            try
            {
                MySqlCommand Comm;
                DatabaseConnection = conexaoBanco();

                Comm = DatabaseConnection.CreateCommand();

                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "SELECT COUNT(*) FROM SERVICO WHERE MANUTENCAO_DATA LIKE '%" + data.Year + "/" + data.Month +"%'" ;

                return int.Parse(Comm.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (DatabaseConnection.State == ConnectionState.Open)
                {
                    DatabaseConnection.Dispose();
                }
            }
        }

        public void AgendarManutencao(GlobalViewModel dados)
        {
            try
            {
                MySqlCommand Comm;
                DatabaseConnection = conexaoBanco();

                Comm = DatabaseConnection.CreateCommand();
                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL, TELEFONE) VALUES (@NOME, @EMAIL, @TELEFONE)";
                Comm.Parameters.AddWithValue("@NOME", dados.Cliente.Nome);
                Comm.Parameters.AddWithValue("@EMAIL", dados.Cliente.EMail);
                Comm.Parameters.AddWithValue("@TELEFONE", dados.Cliente.Telefone);
                Comm.ExecuteNonQuery();

                Comm.CommandText = "INSERT INTO VEICULO (VEICULO_MARCA, VEICULO_MODELO, VEICULO_ANO) VALUES (@VEICULO_MARCA, @VEICULO_MODELO, @VEICULO_ANO)";
                Comm.Parameters.AddWithValue("@VEICULO_MARCA", dados.Veiculo.Marca);
                Comm.Parameters.AddWithValue("@VEICULO_MODELO", dados.Veiculo.Modelo);
                Comm.Parameters.AddWithValue("@VEICULO_ANO", dados.Veiculo.AnoVeiculo);
                Comm.ExecuteNonQuery();

                Comm.CommandText = "INSERT INTO SERVICO (SERVICO_COMPLETO, SERVICO_MECANICA, SERVICO_SUSPENSAO, SERVICO_FREIO, MANUTENCAO_DATA) VALUES (@SERVICO_COMPLETO, @SERVICO_MECANICA, @SERVICO_SUSPENSAO, @SERVICO_FREIO, @MANUTENCAO_DATA)";
                Comm.Parameters.AddWithValue("@SERVICO_COMPLETO", dados.Servico.Completo);
                Comm.Parameters.AddWithValue("@SERVICO_MECANICA", dados.Servico.Mecanica);
                Comm.Parameters.AddWithValue("@SERVICO_SUSPENSAO", dados.Servico.Suspensao);
                Comm.Parameters.AddWithValue("@SERVICO_FREIO", dados.Servico.Freio);
                Comm.Parameters.AddWithValue("@MANUTENCAO_DATA", dados.Servico.DataManutencao);
                Comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (DatabaseConnection.State == ConnectionState.Open)
                {
                    DatabaseConnection.Dispose();
                }
            }
        }

        public List<SelectListItem> PopularMarca()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            try
            {
                MySqlCommand Comm;
                DatabaseConnection = conexaoBanco();

                Comm = DatabaseConnection.CreateCommand();

                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "SELECT * FROM VEICULO_MARCA ORDER BY MARCA_NOME ASC";

                Reader = Comm.ExecuteReader();

                while (Reader.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = Reader["MARCA_NOME"].ToString()
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (DatabaseConnection.State == ConnectionState.Open)
                {
                    DatabaseConnection.Dispose();
                }
            }

            return items;
        }

        public List<SelectListItem> PopularModelo()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            try
            {
                MySqlCommand Comm;
                DatabaseConnection = conexaoBanco();

                Comm = DatabaseConnection.CreateCommand();

                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "SELECT * FROM VEICULO_MODELO ORDER BY MODELO_NOME ASC";

                Reader = Comm.ExecuteReader();

                while (Reader.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = Reader["MODELO_NOME"].ToString()
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (DatabaseConnection.State == ConnectionState.Open)
                {
                    DatabaseConnection.Dispose();
                }
            }

            return items;
        }

        public List<SelectListItem> PopularAno()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            try
            {
                MySqlCommand Comm;
                DatabaseConnection = conexaoBanco();

                Comm = DatabaseConnection.CreateCommand();

                Comm.CommandText = "USE CARSERVICE";
                Comm.ExecuteNonQuery();

                Comm.CommandText = "SELECT * FROM VEICULO_ANO ORDER BY VEICULO_ANO ASC";

                Reader = Comm.ExecuteReader();

                while (Reader.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = Reader["VEICULO_ANO"].ToString()
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (DatabaseConnection.State == ConnectionState.Open)
                {
                    DatabaseConnection.Dispose();
                }
            }

            return items;

        }

        private MySqlConnection conexaoBanco()
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
    }
}