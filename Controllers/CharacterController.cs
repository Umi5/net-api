using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Character;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ServiceResponses;
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
        public async Task<ActionResult<GetCharacterDto>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacter(id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetCharacterDto>>> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<GetCharacterDto>>> AddCharacter (AddCharacterDto addCharacter)
        {
            return Ok(await _characterService.AddCharacter(addCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter (UpdateCharacterDto updatedCharacter)
        {
            var responseCharacter = await _characterService.UpdateCharacter(updatedCharacter);
            if(responseCharacter.Data is null){
                return NotFound(responseCharacter);
            }
            return Ok(responseCharacter);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}