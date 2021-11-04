
using CarService.Models.QueryStack.ViewModels;
using CarService.Models.ServiceStack.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Models.ServiceStack.Interface
{
    public interface IAppServiceHandler
    {
        void AgendarManutencao(ManutencaoModel dados);

        void EnviarEmail(ManutencaoModel dados);

        IList<SelectListItem> PopularMarca();

        List<SelectListItem> PopularModelo();

        List<SelectListItem> PopularAno();

        Task<bool> RetornarOficinaCapacidadeMaxima(DateTime? dataManutencao);

        void EnviarEmailCliente(ManutencaoViewModel dados);
    }
}
