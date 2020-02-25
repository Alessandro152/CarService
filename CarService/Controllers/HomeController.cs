using CarService.Models.QueryStack.ViewModels;
using CarService.Models.ServiceStack.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppServiceHandler _appService;
        private readonly GlobalViewModel _lista;
        private const int CAPACIDADE_MAXIMA = 10;

        public HomeController(IAppServiceHandler appServiceHandler, GlobalViewModel lista)
        {
            _appService = appServiceHandler;

            lista = new GlobalViewModel()
            {
                VeiculoMarca = _appService.PopularMarca(),
                VeiculoModelo = _appService.PopularModelo(),
                VeiculoAno = _appService.PopularAno(),
                AgendaCheia = lista.AgendaCheia,
                AgendaVazia = lista.AgendaVazia
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
            int result = _appService.VerificarDataManutencao(dados.Servico.DataManutencao);

            if (result == CAPACIDADE_MAXIMA)
            {
                _lista.AgendaCheia = true;
                return View("Index", _lista);
            }
            else
            {
                if (dados.Servico.DataManutencao.DayOfWeek == DayOfWeek.Sunday)
                {
                    _lista.Domingo = true;
                    return View("Index", _lista);
                }

                _lista.AgendaVazia = true;
                _appService.AgendarManutencao(dados);
                _appService.EnviarEmail(dados);
                _appService.EnviarEmailCliente(dados);

                return View("Index", _lista);
            }
        }
    }
}