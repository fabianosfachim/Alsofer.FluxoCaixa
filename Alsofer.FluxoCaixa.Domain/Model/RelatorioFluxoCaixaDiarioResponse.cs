using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class RelatorioFluxoCaixaDiarioResponse
    {
        public List<RelatorioFluxoCaixaDiario> relatorio { get; set; }
        public TotalRelatorioFluxoCaixaDiario totalRelatorioFluxoCaixaDiario { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
