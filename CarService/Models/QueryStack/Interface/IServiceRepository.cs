using CarService.Models.QueryStack.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarService.Models.QueryStack.Interface
{
    public interface IServiceRepository
    {
        int VerificarDataManutencao(string data);
        void AgendarManutencao(GlobalViewModel dados);
        List<SelectListItem> PopularMarca();
        List<SelectListItem> PopularModelo();
        List<SelectListItem> PopularAno();
    }
}
