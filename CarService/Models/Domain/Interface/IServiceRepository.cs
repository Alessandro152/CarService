using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Models.QueryStack.Interface
{
    public interface IServiceRepository
    {
        List<SelectListItem> PopularMarca();

        List<SelectListItem> PopularModelo();

        List<SelectListItem> PopularAno();

        Task<bool> VerificarDataManutencao(DateTime data);
    }
}
