using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo_API.Entity;

namespace ProcessoSeletivo_API.Persistence.Context
{
    public class ContextAPI : DbContext
    {
        public ContextAPI(DbContextOptions<ContextAPI> options) : base(options)
        {
        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Candidato> Email { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>(e =>
            {
                e.ToTable("Candidato");
                e.HasKey(c => c.Id);
                e.HasOne(c => c.Email);
            });
            modelBuilder.Entity<EmailEntity>(e =>
            {
                e.ToTable("Emails");
                e.HasKey(c => c.Id);
            });
        }


    }
}
