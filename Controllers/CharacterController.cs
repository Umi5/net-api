using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.CharacterServices;



namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            return Ok(_characterService.GetCharacter(id));
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Character>> GetAllCharacters()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpPost]
        public ActionResult<IEnumerable<Character>> AddCharacter (Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}