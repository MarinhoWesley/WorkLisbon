using Microsoft.AspNetCore.Mvc;
using ApiPerson.Models;
using ApiPerson.Data;

namespace ApiPerson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonModel person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();
                
            return Ok(person);
        }
    }
}