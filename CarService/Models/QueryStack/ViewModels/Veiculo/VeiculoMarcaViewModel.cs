
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarService.Models.QueryStack.ViewModels.Veiculo
{
    public class VeiculoMarcaViewModel
    {
        public bool AgendaCheia { get; set; }
        public bool AgendaVazia { get; set; }
        public List<SelectListItem> VeiculoMarca { get; set; }
        public List<SelectListItem> VeiculoModelo { get; set; }
        public List<SelectListItem> VeiculoAno { get; set; }
    }
}