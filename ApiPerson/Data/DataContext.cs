// Preciso destes para usar banco de dados
using Microsoft.EntityFrameworkCore;
using ApiPerson.Models;

namespace ApiPerson.Data
{
   // Minha classe que controla o banco de dados
   public class DataContext : DbContext
   {
       // Construtor que recebe configurações do banco
       public DataContext(DbContextOptions<DataContext> options) : base(options) 
       { }
       
       // Minha tabela de pessoas no banco
       public DbSet<PersonModel> Persons { get; set; }

       // Configuro o SQLite como meu banco
       protected override void OnConfiguring(DbContextOptionsBuilder options)
       {
           if (!options.IsConfigured)
           {
               // Crio um arquivo pessoas.db como banco
               options.UseSqlite("Data Source=pessoas.db");
           }
       }
   }
}