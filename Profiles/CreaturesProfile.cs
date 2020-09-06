using AutoMapper;
using Heroes_3_Creatures.Dtos;
using Heroes_3_Creatures.Models;
using System;
using System.Collections.Generic;

namespace Heroes_3_Creatures.Profiles
{
    public class CreaturesProfile : Profile
    {
        public CreaturesProfile()
        {
            CreateMap<ResourceCost, ResourceCostDto>().ForMember(rcdto=>rcdto.Resource, x=>x.MapFrom(rc=>rc.Resource.Name));
            CreateMap<CreatureAbility, String>().ConvertUsing(ca => ca.Ability.AbilityText);
            CreateMap<Creature, CreatureReadDto>().ForMember(c => c.Abilities, x => x.MapFrom(c => c.CreatureAbilities));
            CreateMap<Fraction, CreatureReadDto>();
        }
    }
}
