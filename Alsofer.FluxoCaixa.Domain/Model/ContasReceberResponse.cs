using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class ContasReceberResponse
    {
        public List<ContasReceber> ContasReceber { get; set; }
        public ContasReceber objContasReceber { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
