﻿using CarService.Models.QueryStack.ViewModels;
using CarService.Models.ServiceStack.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppServiceHandler _appService;
        private readonly GlobalViewModel _lista;
        private const int CAPACIDADE_MAXIMA = 5;

        public HomeController(IAppServiceHandler appServiceHandler, GlobalViewModel lista)
        {
            _appService = appServiceHandler;

            lista = new GlobalViewModel()
            {
                VeiculoMarca = _appService.PopularMarca(),
                VeiculoModelo = _appService.PopularModelo(),
                VeiculoAno = _appService.PopularAno()
            };

            _lista = lista;
        }

        public ActionResult Index()
        {
            return View(_lista);
        }

        [HttpPost]
        public ActionResult SaveData(GlobalViewModel dados)
        {
            dados.Servico.DataManutencao = dados.Servico.DataManutencao.Replace("-", "");
            var result = _appService.VerificarDataManutencao(dados.Servico.DataManutencao);

            if (result == CAPACIDADE_MAXIMA)
            {
                ViewBag.Alert = "Infelizmente estou com agenda cheia para " + RetornarDataManutencao(dados) + ". Escolha outra data.";
                return View("Index", _lista);
            }
            else
            {
                _appService.AgendarManutencao(dados);
                _appService.EnviarEmail(dados);

                ViewBag.Alert = "Agendamento realizado com sucesso";
                return RedirectToAction("Index");
            }
        }

        private string RetornarDataManutencao(GlobalViewModel dados)
        {
            return dados.Servico.DataManutencao.Substring(6, 2) + "/" + dados.Servico.DataManutencao.Substring(4, 2) + "/" + dados.Servico.DataManutencao.Substring(0, 4);
        }
    }
}