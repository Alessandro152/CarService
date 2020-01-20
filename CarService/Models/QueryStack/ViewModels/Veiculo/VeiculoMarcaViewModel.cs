
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarService.Models.QueryStack.ViewModels.Veiculo
{
    public class VeiculoMarcaViewModel
    {
        public List<SelectListItem> VeiculoMarca { get; set; }
        public List<SelectListItem> VeiculoModelo { get; set; }
        public List<SelectListItem> VeiculoAno { get; set; }
    }
}