
using CarService.Models.QueryStack.Interface;
using CarService.Models.QueryStack.ViewModels;
using CarService.Models.ServiceStack.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace CarService.Models.ServiceStack.AppService
{
    public class AppServiceHandler : IAppServiceHandler
    {
        private readonly IServiceRepository _repo;
        private const string EMAIL_ACESSO = "alessandro_hudson@hotmail.com";
        private const string EMAIL_SENHA = "cessna152";

        public AppServiceHandler(IServiceRepository repo)
        {
            _repo = repo;
        }

        public int VerificarDataManutencao(DateTime data)
        {
            return _repo.VerificarDataManutencao(data);
        }

        public void AgendarManutencao(GlobalViewModel dados)
        {
            _repo.AgendarManutencao(dados);
        }

        public List<SelectListItem> PopularMarca()
        {
            return _repo.PopularMarca();
        }

        public List<SelectListItem> PopularModelo()
        {
            return _repo.PopularModelo();
        }

        public List<SelectListItem> PopularAno()
        {
            return _repo.PopularAno();
        }

        public void EnviarEmail(GlobalViewModel dados)
        {
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.live.com",
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(EMAIL_ACESSO, EMAIL_SENHA)
            };
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("alessandro_hudson@hotmail.com", "Sistema de agendamento de manutenções")
            };
            mail.To.Add(new MailAddress("alessandro_hudson@hotmail.com"));
            mail.Subject = "Agendamento cliente " + dados.Cliente.Nome;
            mail.Body = " Olá!! Abaixo segue dados do cliente que agendou manutenção de seu carango : <br/><br/>" +
                                          "Dados do cliente :<br/> Nome:  " + dados.Cliente.Nome +
                                          "<br/> Email : " + dados.Cliente.EMail +
                                          "<br/> Telefone : " + dados.Cliente.Telefone +
                                          "<br/> Marca Veiculo : " + dados.Veiculo.Marca.ToString() +
                                          "<br/> Modelo Veiculo : " + dados.Veiculo.Modelo.ToString() +
                                          "<br/> Ano Veiculo : " + dados.Veiculo.AnoVeiculo.ToString() +
                                          "<br/> Data de manutenção solicitada : " + FormatarDataManutencao(dados.Servico.DataManutencao.ToString()) +
                                          "<br/> Serviços a serem feitos : <br />";
            if (dados.Servico.Completo == true)
            {
                mail.Body += "- Serviço completo <br/>";
            }
            if (dados.Servico.Mecanica == true)
            {
                mail.Body += "- Serviço de mecânica <br />";
            }
            if (dados.Servico.Suspensao == true)
            {
                mail.Body += "- Serviço de suspensão <br />";
            }
            if (dados.Servico.Freio == true)
            {
                mail.Body += "- Serviço de freio";
            }

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                mail = null;
            }
        }

        private string FormatarDataManutencao(string dataManutencao)
        {
            return dataManutencao.Substring(6, 2) + "/ " + dataManutencao.Substring(4, 2) + "/ " + dataManutencao.Substring(0, 4);
        }
    }
}