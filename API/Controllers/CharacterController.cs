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
        [Route("{name}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(string name)
        {
            var response = await _characterService.GetCharacter(name);
            if(response is null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCharacterDto>>>> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCharacterDto>>>> AddCharacter (AddCharacterDto addCharacter)
        {
            var response = await _characterService.AddCharacter(addCharacter);
            if(!response.Success){
                return Ok(response);
            }
            return Ok(response);
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
        [Route("{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetCharacterDto>>>> DeleteCharacter(string name)
        {
            var response = await _characterService.DeleteCharacter(name);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}