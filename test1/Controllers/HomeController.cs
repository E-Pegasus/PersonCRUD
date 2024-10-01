
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

using test1.Entities;

namespace test1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        // create, delete, update, get

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetPersons/{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            //finding the person just by its id because the id is uniqe from all
            var person = await _context.people.FindAsync(id);
            return Ok(person);
        }

        [HttpGet]
        [Route("GetAllPersons")]
        public async Task<ActionResult<List<Person>>> GetAllPerson()
        {
            //listing all the person data from the db using tolistasync function
            var all = await _context.people.ToListAsync();
            return Ok(all);
        }


        [HttpPut]
        [Route("UpdatePerson")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, string Name,int age ,string Desctiption)
        {
            var person = await _context.people.FindAsync(id);
            //var person = GetPerson(id);

            // checking if the data is existed on the db before updating
            if (person != null) {

                //modifing data then write on the db
                person.Name = Name;
                person.Age = age;
                person.Description = Desctiption;

                _context.people.Update(person);
                await _context.SaveChangesAsync();

            }
            else
            {
                return BadRequest("id not found!");
            }

            return Ok("person updated!");
        }


        //creatin a person on db
        [HttpPost]
        [Route("CreatePerson")]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            _context.people.Add(person);
            await _context.SaveChangesAsync();
            return Ok("person saved!");
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.people.FindAsync(id);

            //var person = GetPerson(id);

            if (person != null)
            {
                _context.people.Remove(person);
                await _context.SaveChangesAsync();

            }
            else
            {
                BadRequest("cant find the person");
            }
            return Ok("person deleted!");
        }
    }
}
