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
        Task<IEnumerable<GetCharacterDto>> GetAllCharacters();
        Task<GetCharacterDto> GetCharacter(int id);
        Task<IEnumerable<GetCharacterDto>> AddCharacter (AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter (UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<IEnumerable<GetCharacterDto>>> DeleteCharacter(int id);
    }
}