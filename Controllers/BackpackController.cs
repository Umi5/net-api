using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Backpack;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceResponses;
using Services.BackpackServices;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackpackController : ControllerBase
    {
        private readonly IBackpackService _backpackService;

        public BackpackController(IBackpackService backpackService)
        {
            this._backpackService = backpackService;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<ServiceResponse<BackpackDto>>> GetBackpackByCharacterName(string name)
        {
            var response = await _backpackService.GetBackpackByCharacterName(name);
            if(response is null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("{name}")]
        public async Task<ActionResult<ServiceResponse<BackpackDto>>> CreateBackpackByUsername(string name)
        {
            var response = await _backpackService.CreateBackpackByUsername(name);
            if(response is null){
                return NotFound(response);
            }
            return Ok(response);
        }

        
    }
}