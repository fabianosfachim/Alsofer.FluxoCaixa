using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;


namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{
    public class DespesaRespository : EntityBaseRepository<Despesa>, IDespesaRepository

    {
        private readonly ApplicationContext _db;
        public DespesaRespository(ApplicationContext context) : base(context)
        {
            _db = context;
        }

        
    }
}
