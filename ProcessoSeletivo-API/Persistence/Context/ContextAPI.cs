using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo_API.Entity;

namespace ProcessoSeletivo_API.Persistence.Context
{
    public class ContextAPI : DbContext
    {
        public ContextAPI(DbContextOptions<ContextAPI> options) : base(options) { }

        public DbSet<Candidato> Candidato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>(e =>
            {
                e.ToTable("Candidato");
                e.HasKey(c => c.Id);
            });
        }
    }
}
