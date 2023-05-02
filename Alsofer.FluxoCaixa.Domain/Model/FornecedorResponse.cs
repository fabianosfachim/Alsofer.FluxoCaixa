using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class FornecedorResponse
    {
        public List<Fornecedor> Fornecedor { get; set; }
        public Fornecedor objFornecedor { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
