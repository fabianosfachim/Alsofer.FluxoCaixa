using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Data.Repositories.Entities
{

    public class LoginRepository : EntityBaseRepository<Login>, ILoginRepository

    {
        private readonly ApplicationContext _db;
        public LoginRepository(ApplicationContext context) : base(context)
        {
            _db = context;
        }
    }
}
