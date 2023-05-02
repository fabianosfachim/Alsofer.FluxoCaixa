using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class ReceitaResponse
    {
        public List<Receita> Receita { get; set; }
        public Receita objReceita { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
