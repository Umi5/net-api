using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceResponses;
using Services.WeaponService;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponController: ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            this._weaponService = weaponService;
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<WeaponDto>>> CreateWeaponByUsername(string characterName, string weaponName, int weaponDamage)
        {
            var response = await _weaponService.CreateWeaponByUsername(characterName,weaponName,weaponDamage);
            if(response is null){
                return NotFound(response);
            }
            return Ok(response);
        }

        
    }
}