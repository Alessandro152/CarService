
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
        private const string MAPA = "https://goo.gl/maps/LFbgszmwHC4Dwuvp7";

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
                                          "<br/> Data de manutenção solicitada : " + dados.Servico.DataManutencao.Day + "/" + dados.Servico.DataManutencao.Month + "/" + dados.Servico.DataManutencao.Year +
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

        public void EnviarEmailCliente(GlobalViewModel dados)
        {
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.live.com",
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(EMAIL_ACESSO, EMAIL_SENHA)
            };
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("alessandro_hudson@hotmail.com", "Não Responda: Sistema de agendamento de manutenções")
            };
            mail.To.Add(new MailAddress(dados.Cliente.EMail));
            mail.Subject = "Agendamento cliente " + dados.Cliente.Nome;
            mail.Body = " Olá!! Está confirmado a manutenção de seu veículo para " + dados.Servico.DataManutencao.Day + "/" + dados.Servico.DataManutencao.Month + "/" + dados.Servico.DataManutencao.Year + ". O endereço da oficina é: " +
                        "Rua Valdemar Martins, 1110 - Parque Peruche, São Paulo. Link do Google Maps: " + MAPA;

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
    }
}