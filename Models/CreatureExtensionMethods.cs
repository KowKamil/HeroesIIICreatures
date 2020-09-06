using Heroes_3_Creatures.Dtos;
using System.Linq;

namespace Heroes_3_Creatures.Models
{
    public static class CreatureExtensionMethods
    {
        public static CreatureReadDto MapCreatureToDto(this Creature creature)
        {
            //manual mapping in case Automapper acts up
            if (creature == null)
                return null;

            CreatureReadDto crdto = new CreatureReadDto
            {
                Id = creature.Id,
                Name = creature.Name,
                FractionName = creature?.Fraction?.Name,
                UpgradedFrom = creature?.UpgradedFrom.MapCreatureToDto(),
                Tier = creature.Tier,
                Attack = creature.Attack,
                Defense = creature.Defense,
                Shots = creature.Shots,
                DamageMinimum = creature.DamageMinimum,
                DamageMaximum = creature.DamageMaximum,
                Health = creature.Health,
                Speed = creature.Speed,
                Abilities = creature.CreatureAbilities?.Select(x => x.Ability.AbilityText).ToList(),
                GoldCost = creature.GoldCost,
                ResourceCosts = creature.ResourceCosts?.Select(x => new ResourceCostDto { Resource = x.Resource.Name, Amount = x.Amount }).ToList(),
                BaseGrowth = creature.BaseGrowth
            };

            return crdto;
        }
    }
}
