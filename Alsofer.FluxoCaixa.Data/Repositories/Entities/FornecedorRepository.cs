using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{

    public class FornecedorRepository : EntityBaseRepository<Fornecedor>, IFornecedorRepository

    {
        private readonly ApplicationContext _db;
        public FornecedorRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
    }
}
