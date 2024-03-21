using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos;
using Dtos.Backpack;
using Models;
using Models.ServiceResponses;

namespace Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public WeaponService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ServiceResponse<WeaponDto>> CreateWeaponByUsername(string characterName, string weaponName, int weaponDamage)
        {
            var serviceResponse = new ServiceResponse<WeaponDto>();
            try{
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Name == characterName);
                if (character is null){
                    throw new Exception($"Character with name '{characterName}' not found");
                }

                await _context.Weapons.AddAsync(new Weapon{
                    Id = Guid.NewGuid(),
                    Name = weaponName,
                    Damage = weaponDamage,
                    CharacterId = character.Id
                });
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = new WeaponDto {
                    Name = weaponName,
                    Damage = weaponDamage 
                };
                serviceResponse.Success = true;
                serviceResponse.Message = $"Arma añadida al personaje {characterName}";

            }catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}