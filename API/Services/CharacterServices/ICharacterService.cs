using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Character;
using Models;
using Models.ServiceResponses;

namespace Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponse<IEnumerable<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacter(string name);
        Task<ServiceResponse<IEnumerable<GetCharacterDto>>> DeleteCharacter(string name);
        Task<ServiceResponse<IEnumerable<GetCharacterDto>>> AddCharacter (AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter (UpdateCharacterDto updatedCharacter);
        
    }
}