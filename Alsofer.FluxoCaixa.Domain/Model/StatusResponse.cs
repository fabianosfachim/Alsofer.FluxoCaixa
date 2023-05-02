using Alsofer.FluxoCaixa.Domain.Entities;


namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class StatusResponse
    {
        public List<Status> status { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
