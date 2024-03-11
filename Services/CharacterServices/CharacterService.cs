using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Character;
using Microsoft.AspNetCore.Http.HttpResults;
using Models;

namespace Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static IList<Character> personajes = new List<Character> {
            new Character {Name = "Manu", Id = 1},
            new Character {Name = "Luis", Id = 2},
            new Character {Name = "Xexu", Id = 3}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<IEnumerable<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            
            personajes.Add(_mapper.Map<Character>(newCharacter));
            var charactersList = _mapper.Map<IEnumerable<GetCharacterDto>>(personajes);
            return charactersList;
        }

        public async Task<IEnumerable<GetCharacterDto>> GetAllCharacters()
        {
            
            return _mapper.Map<IEnumerable<GetCharacterDto>>(personajes); 
        }

        public async Task<GetCharacterDto> GetCharacter(int id)
        {
            var character = personajes.FirstOrDefault(c => c.Id == id);

            if (character is not null)
                return _mapper.Map<GetCharacterDto>(character);
            
            throw new Exception("Character NOT found");
        }
    }
}