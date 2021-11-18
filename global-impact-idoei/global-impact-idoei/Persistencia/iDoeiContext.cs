using global_impact_idoei.Models;
using Microsoft.EntityFrameworkCore;


namespace global_impact_idoei.Persistencia
{
    public class iDoeiContext : DbContext
    {
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public iDoeiContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doacao>().HasKey(x => new { x.IdOng, x.IdEmpresa, x.IdAlimento });
        }
    }
}
