using Microsoft.EntityFrameworkCore;
using MedGrupo.Domain;

namespace MedGrupo.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Requisito: Filtro global para trazer apenas contatos ativos em toda a aplicação
            modelBuilder.Entity<Contato>().HasQueryFilter(c => c.Ativo);

            base.OnModelCreating(modelBuilder);
        }
    }
}