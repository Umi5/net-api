using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Character;
using Microsoft.AspNetCore.Http.HttpResults;
using Models;
using Models.ServiceResponses;

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
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<IEnumerable<GetCharacterDto>> GetAllCharacters()
        {
            var dbCharacters = await _context.Characters.ToListAsync();
            return _mapper.Map<IEnumerable<GetCharacterDto>>(dbCharacters); 
        }

         public async Task<GetCharacterDto> GetCharacter(int id)
        {
            var character = await _context.Characters.Where(c => c.Id == id).SingleOrDefaultAsync();
            
            if (character is not null)
                return _mapper.Map<GetCharacterDto>(character);
            
            throw new Exception("Character NOT found");
        }

        public async Task<IEnumerable<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = 3;
            await _context.Characters.AddAsync(_mapper.Map<Character>(newCharacter));
            await _context.SaveChangesAsync();
            var characterList = await _context.Characters.ToListAsync();
            var charactersResponse = _mapper.Map<IEnumerable<GetCharacterDto>>(characterList);
            return charactersResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCharacterDto>>();
            try
            {
                var character = await _context.Characters.Where(c => c.Id == id).SingleOrDefaultAsync();
                
                if(character is null)
                {
                    throw new Exception($"Character with ID '{id}' not found");
                }
                personajes.Remove(character);

                serviceResponse.Data = personajes.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            }catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = personajes.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if(character is null)
                {
                    throw new Exception($"Character with ID '{updatedCharacter.Id}' not found");
                }
                
                character.Name = updatedCharacter.Name;
                character.Hitpoints = updatedCharacter.Hitpoints;
                character.Strenght = updatedCharacter.Strenght;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            }catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
           
        }
    }
}