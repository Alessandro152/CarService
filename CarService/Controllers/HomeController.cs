using CarService.Models.Application.Interface;
using CarService.Models.QueryStack.ViewModels;
using CarService.Models.ServiceStack.Entities;
using CarService.Models.ServiceStack.Interface;
using CarService.Models.ViewModels.Veiculo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppServiceHandler _appService;
        private readonly IUnitOfWork _unitOfWork;
        private ManutencaoViewModel _dadosManutencao;

        public HomeController(IAppServiceHandler appServiceHandler, IUnitOfWork unitOfWork)
        {
            _appService = appServiceHandler;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            _dadosManutencao = new ManutencaoViewModel
            {
                AgendaCheia = false,
                AgendaVazia = false,
                Domingo = false,
                Veiculo = RetornarTodosVeiculos().Result
            };

            return View(_dadosManutencao);
        }

        [HttpPost]
        public IActionResult AgendarServico(ManutencaoModel dados)
        {
            var result = _appService.RetornarOficinaCapacidadeMaxima(dados.DataManutencao).Result;

            if (!result)
            {
                _dadosManutencao.AgendaCheia = true;
                return View(nameof(Index), _dadosManutencao);
            }
            else
            {
                if (dados.DataManutencao.DayOfWeek == DayOfWeek.Sunday)
                {
                    _dadosManutencao.Domingo = true;
                    return View(nameof(Index), _dadosManutencao);
                }

                _dadosManutencao.AgendaVazia = true;
                result = _appService.AgendarManutencao(dados);

                if (result) 
                {
                    _unitOfWork.Commit();
                }
                else
                {
                    _unitOfWork.RollBack();
                }

                _appService.EnviarEmail(dados);

                return View(nameof(Index), _dadosManutencao);
            }
        }

        protected Task<VeiculoViewModel> RetornarTodosVeiculos()
        {
            return Task.FromResult(new VeiculoViewModel());
        }
    }
}