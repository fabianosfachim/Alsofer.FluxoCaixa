using Microsoft.EntityFrameworkCore;
using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ContasPagar> ContasPagar { get; set; }
        public DbSet<ContasReceber> ContasReceber { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}