using Microsoft.EntityFrameworkCore;
using ApiPerson.Models;

namespace ApiPerson.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<PersonModel> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.OwnsOne(e => e.Endereco, endereco =>
                {
                    endereco.Property(e => e.Rua).HasColumnName("Rua");
                    endereco.Property(e => e.Numero).HasColumnName("Numero");
                    endereco.Property(e => e.Complemento).HasColumnName("Complemento");
                });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Isso garante que usamos SQLite mesmo se não houver configuração específica
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=pessoas.db");
            }
        }
    }
}