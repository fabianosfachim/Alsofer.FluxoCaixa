using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{
    public class ClienteRepository : EntityBaseRepository<Cliente>, IClienteRepository

    {
        private readonly ApplicationContext _db;
        public ClienteRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
    }
}
