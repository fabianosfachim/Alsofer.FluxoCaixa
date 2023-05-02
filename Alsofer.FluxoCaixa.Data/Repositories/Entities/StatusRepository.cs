using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{

    public class StatusRepository : EntityBaseRepository<Status>, IStatusRepository

    {
        private readonly ApplicationContext _db;
        public StatusRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
    }
}
