using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static IList<Character> personajes = new List<Character> {
            new Character {Name = "Manu", Id = 1},
            new Character {Name = "Luis", Id = 2},
            new Character {Name = "Xexu", Id = 3}
        };

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Character> GetPersonaje(int id)
        {
            return Ok(personajes.FirstOrDefault(c => c.Id == id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Character>> GetPersonajes()
        {
            return Ok(personajes);
        }
    }
}