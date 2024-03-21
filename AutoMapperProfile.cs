using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using Dtos.Backpack;
using Dtos.Character;
using Models;

namespace _netCrash
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<Weapon,WeaponDto>();
            CreateMap<Backpack,BackpackDto>();
        }
    }
}