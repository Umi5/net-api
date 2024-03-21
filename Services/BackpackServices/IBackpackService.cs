using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Backpack;
using Models.ServiceResponses;

namespace Services.BackpackServices
{
    public interface IBackpackService
    {
        Task<ServiceResponse<BackpackDto>> CreateBackpackByUsername(string name);
    }
}