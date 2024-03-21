using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos;
using Dtos.Backpack;
using Models.ServiceResponses;

namespace Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<WeaponDto>> CreateWeaponByUsername(string characterName, string weaponName, int weaponDamage);
    }
}