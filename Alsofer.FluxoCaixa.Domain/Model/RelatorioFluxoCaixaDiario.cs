namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class RelatorioFluxoCaixaDiario
    {
        public int dia { get; set; }
        public decimal despesa { get; set; }
        public decimal receita { get; set; }
        public decimal contasPagar { get; set; }
        public decimal contasReceber { get; set; }
        public decimal saldoDia { get; set; }
    }

    public class TotalRelatorioFluxoCaixaDiario
    {
        public decimal despesa { get; set; }
        public decimal receita { get; set; }
        public decimal contasPagar { get; set; }
        public decimal contasReceber { get; set; }
        public decimal saldoTotal { get; set; }
    }
}
