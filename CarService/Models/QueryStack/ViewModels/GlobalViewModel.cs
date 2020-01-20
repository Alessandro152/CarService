
using CarService.Models.QueryStack.ViewModels.Cliente;
using CarService.Models.QueryStack.ViewModels.Servico;
using CarService.Models.QueryStack.ViewModels.Veiculo;
using CarService.Models.ViewModels.Veiculo;

namespace CarService.Models.QueryStack.ViewModels
{
    public class GlobalViewModel : VeiculoMarcaViewModel
    {
        public ClienteViewModel Cliente { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
        public ServicoViewModel Servico { get; set; }
    }
}