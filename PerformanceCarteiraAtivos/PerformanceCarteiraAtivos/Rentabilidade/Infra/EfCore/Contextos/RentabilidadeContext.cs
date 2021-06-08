using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerformanceCarteiraAtivos.Rentabilidade;

namespace PerformanceCarteiraAtivos.Infra.Contextos.EFCore
{
    public class RentabilidadeContext : DbContext
    {
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Investidor> Investidores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Rentabilidade");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarteiraBuilder().Configure(modelBuilder.Entity<Carteira>());
            new InvestidorBuilder().Configure(modelBuilder.Entity<Investidor>());
        }
    }

    public class CarteiraBuilder : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> b)
        {
            b.HasKey(pk => pk.Id);

            b
            .HasOne(o => o.Investidor)
            .WithMany(m => m.Carteiras);

            b
            .OwnsMany(o => o.Acoes, a => a.WithOwner().HasForeignKey(fk => fk.CarteiraId));

        }
    }

    public class InvestidorBuilder : IEntityTypeConfiguration<Investidor>
    {
        public void Configure(EntityTypeBuilder<Investidor> b)
        {
            b.HasKey(pk => pk.Id);
        }
    }
}
