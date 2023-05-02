using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;


namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{
    public class ReceitaRepository : EntityBaseRepository<Receita>, IReceitaRepository

    {
        private readonly ApplicationContext _db;
        public ReceitaRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
    }
}
