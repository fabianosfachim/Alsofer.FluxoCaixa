using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class DespesaResponse
    {
        public List<Despesa> Despesa { get; set; }
        public Despesa objDespesa { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
