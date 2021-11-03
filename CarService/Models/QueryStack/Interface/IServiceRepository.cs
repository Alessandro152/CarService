using CarService.Models.QueryStack.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CarService.Models.QueryStack.Interface
{
    public interface IServiceRepository
    {
        void AgendarManutencao(ManutencaoModel dados);
        List<SelectListItem> PopularMarca();
        List<SelectListItem> PopularModelo();
        List<SelectListItem> PopularAno();
        int VerificarDataManutencao(DateTime data);
    }
}
