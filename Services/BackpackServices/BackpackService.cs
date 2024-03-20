using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Backpack;
using Models;
using Models.ServiceResponses;

namespace Services.BackpackServices
{
    public class BackpackService : IBackpackService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BackpackService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ServiceResponse<BackpackDto>> CreateBackpackByUsername(string name)
        {
            var serviceResponse = new ServiceResponse<BackpackDto>();
            try{
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Name == name);
                if (character is null){
                    throw new Exception($"Character with name '{name}' not found");
                }

                var backpack = await _context.Backpacks.FirstOrDefaultAsync(b => b.CharacterId == character.Id);
                if (backpack is not null){
                    throw new Exception($"Character with name '{name}' already has a backpack");
                }
                
                await _context.Backpacks.AddAsync(new Backpack{
                    Id = Guid.NewGuid(),
                    Name = $"Mochila de {name}",
                    CharacterId = character.Id
                });
                _context.SaveChanges();

                serviceResponse.Data = new BackpackDto {
                    CharacterName = character.Name,
                    Name = $"Mochila de {name}"
                };

                serviceResponse.Success = true;
                serviceResponse.Message = $"Backpack for {name} created";

            }catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<BackpackDto>> GetBackpackByCharacterName(string name)
        {
            var serviceResponse = new ServiceResponse<BackpackDto>();
            try{
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Name == name);
                if (character is null){
                    throw new Exception($"Character with name '{name}' not found");
                }

                var backpack = await _context.Backpacks.FirstOrDefaultAsync(b => b.CharacterId == character.Id);
                if (backpack is null){
                    throw new Exception($"Character with name '{name}' does NOT have a backpack");
                }
                
                serviceResponse.Data = new BackpackDto {
                    CharacterName = character.Name,
                    Name = backpack.Name
                };
                serviceResponse.Message = "Success";
                serviceResponse.Success = true;

            }catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}