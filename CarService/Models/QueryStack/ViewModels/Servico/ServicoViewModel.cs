
using System;

namespace CarService.Models.QueryStack.ViewModels.Servico
{
    public class ServicoViewModel
    {
        public bool Completo { get; set; }
        public bool Mecanica { get; set; }
        public bool Suspensao { get; set; }
        public bool Freio { get; set; }
        public DateTime DataManutencao { get; set; }

    }
}