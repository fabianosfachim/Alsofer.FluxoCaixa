using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class ContasPagarResponse
    {
        public List<ContasPagar> ContasPagar { get; set; }
        public ContasPagar objContasPagar { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
