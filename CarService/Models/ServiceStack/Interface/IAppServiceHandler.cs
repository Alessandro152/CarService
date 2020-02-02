
using CarService.Models.QueryStack.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CarService.Models.ServiceStack.Interface
{
    public interface IAppServiceHandler
    {
        void AgendarManutencao(GlobalViewModel dados);
        void EnviarEmail(GlobalViewModel dados);
        List<SelectListItem> PopularMarca();
        List<SelectListItem> PopularModelo();
        List<SelectListItem> PopularAno();
        int VerificarDataManutencao(DateTime dataManutencao);
    }
}
