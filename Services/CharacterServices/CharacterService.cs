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

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacter(string name)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try{
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Name == name);
            
            if (character is null){
                throw new Exception($"Character with name '{name}' not found");
            }
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                serviceResponse.Success = true;
                serviceResponse.Message = $"Character {name} found";

            }catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCharacterDto>>();

            try{
                var checkCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Name == newCharacter.Name);
                if(checkCharacter is not null){
                    throw new Exception($"Character with name '{newCharacter.Name}' already created");
                }

                await _context.Characters.AddAsync(_mapper.Map<Character>(newCharacter));
                await _context.SaveChangesAsync();

                var characterList = await _context.Characters.ToListAsync();
                serviceResponse.Data = characterList.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

                serviceResponse.Message = $"Character with name '{newCharacter.Name}' created";
                serviceResponse.Success = true;
            }catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCharacterDto>>> DeleteCharacter(string name)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCharacterDto>>();
            try
            {
                var character = await _context.Characters.Where(c => c.Name == name).SingleOrDefaultAsync();
                
                if(character is null)
                {
                    throw new Exception($"Character with NAME '{name}' not found");
                }
                _context.Characters.Remove(character);
                _context.SaveChanges();
                var characterList = await _context.Characters.ToListAsync();
                serviceResponse.Data = characterList.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

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
                var character = await _context.Characters.FirstAsync(c => c.Name == updatedCharacter.Name);
                if(character is null)
                {
                    throw new Exception($"Character with ID '{updatedCharacter.Name}' not found");
                }
                
                character.Name = updatedCharacter.Name;
                character.Hitpoints = updatedCharacter.Hitpoints;
                character.Strenght = updatedCharacter.Strenght;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;
                _context.SaveChanges();

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