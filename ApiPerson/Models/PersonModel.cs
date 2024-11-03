using Microsoft.EntityFrameworkCore;
namespace ApiPerson.Models
{
    public class PersonModel
    {
        public int Id { get; set; }  
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Nif { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
    }
    
[Owned] // Preciso poque nao tenho id definido 
    public class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
    }
}