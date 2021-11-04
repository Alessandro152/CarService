
using CarService.Models.QueryStack.ViewModels.Cliente;
using CarService.Models.QueryStack.ViewModels.Servico;
using CarService.Models.QueryStack.ViewModels.Veiculo;
using CarService.Models.ViewModels.Veiculo;

namespace CarService.Models.QueryStack.ViewModels
{
    public class ManutencaoViewModel
    {
        public ClienteViewModel Cliente { get; set; }

        public VeiculoViewModel Veiculo { get; set; }

        public ServicoViewModel Servico { get; set; }

        public bool Domingo { get; set; }

        public bool AgendaCheia { get; set; }

        public bool AgendaVazia { get; set; }
    }
}