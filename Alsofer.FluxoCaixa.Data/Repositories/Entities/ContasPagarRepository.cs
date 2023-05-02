using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{
    public class ContasPagarRepository : EntityBaseRepository<ContasPagar>, IContasPagarRepository
    {
        private readonly ApplicationContext _db;
        public ContasPagarRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
    }



}
