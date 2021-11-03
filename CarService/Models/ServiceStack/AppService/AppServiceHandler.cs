
using CarService.Models.QueryStack.Interface;
using CarService.Models.QueryStack.ViewModels;
using CarService.Models.ServiceStack.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using CarService.Models.Resources;
using System.Text;

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

        public void AgendarManutencao(ManutencaoModel dados)
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

        public void EnviarEmail(ManutencaoModel dados)
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
            mail.Subject = $"Agendamento cliente {dados.Cliente.Nome}";

            var texto = new StringBuilder($@"Olá!! Abaixo segue dados do cliente que agendou manutenção de seu carango: 
                                          Dados do cliente:
                                          Nome: {dados.Cliente.Nome}
                                          Email: {dados.Cliente.EMail} 
                                          Telefone: {dados.Cliente.Telefone}
                                          Marca Veiculo: {dados.Veiculo.Marca}
                                          Modelo Veiculo: {dados.Veiculo.Modelo}
                                          Ano Veiculo: {dados.Veiculo.AnoVeiculo}
                                          Data de manutenção solicitada: {dados.Servico.DataManutencao.Day}/{dados.Servico.DataManutencao.Month}/{dados.Servico.DataManutencao.Year}
                                          Serviços a serem feitos: ");
            if (dados.Servico.Completo)
            {
               texto.Append("- Serviço completo");
            }
            if (dados.Servico.Mecanica)
            {
                texto.Append("- Serviço de mecânica");
            }
            if (dados.Servico.Suspensao)
            {
                texto.Append("- Serviço de suspensão");
            }
            if (dados.Servico.Freio)
            {
                texto.Append("- Serviço de freio");
            }

            mail.Body = texto.ToString();
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
        }

        public void EnviarEmailCliente(ManutencaoModel dados)
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
            mail.Subject = $"Agendamento cliente {dados.Cliente.Nome}";
            mail.Body = $"{MessageResource.MensagemEndereco}{MessageResource.EnderecoMapa}";

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