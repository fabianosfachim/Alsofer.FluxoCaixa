using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{
    public class ContasReceberRepository : EntityBaseRepository<ContasReceber>, IContasReceberRepository

    {
        private readonly ApplicationContext _db;
        public ContasReceberRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
    }
}
