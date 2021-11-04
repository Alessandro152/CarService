using System;

namespace CarService.Models.ServiceStack.Entities
{
    public class ManutencaoModel
    {
        public string ClienteNome { get; set; }

        public string ClienteEmail { get; set; }

        public string ClienteTelefone { get; set; }

        public string ClienteVeiculoMarca { get; set; }

        public string ClienteVeiculoModelo { get; set; }

        public string ClienteVeiculoAno { get; set; }

        public bool ClienteServicoCompleto { get; set; }

        public bool ClienteServicoMecanica { get; set; }

        public bool ClienteServicoSuspensao { get; set; }

        public bool ClienteServicoFreio { get; set; }

        public DateTime DataManutencao { get; set; }
    }
}
