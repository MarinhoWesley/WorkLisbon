using Microsoft.AspNetCore.Mvc; 
using ApiPerson.Models;         // Aqui está minha classe Person que criei
using ApiPerson.Data;          

namespace ApiPerson.Controllers
{
    [ApiController] // Coloco isso para dizer que é uma API
    [Route("api/person")] // Endereço acesso API
    public class PersonController : ControllerBase
    {
        // Preciso dessa variável privada para guardar minha conexão com o banco
        private readonly DataContext _context;

        // Este é meu construtor, ele roda quando minha classe é criada
        public PersonController(DataContext context)
        {
            _context = context;
        }

        // Esse método cria uma pessoa nova no banco
        [HttpPost] 
        public async Task<PersonModel> Create(PersonModel person)
        {
            _context.Persons.Add(person);
            // Salvo
            await _context.SaveChangesAsync();
            return person;
        }

        // Metodo para buscar
        [HttpGet("{id}")] 
        public async Task<PersonModel> Get(int id)
        {
            return await _context.Persons.FindAsync(id);
        }
    }
}