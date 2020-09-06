using Heroes_3_Creatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_3_Creatures.Dtos
{
    public class CreatureReadDto //TODO figure out mapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FractionName { get; set; }
        public CreatureReadDto UpgradedFrom { get; set; }
        public int Tier { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Shots { get; set; }
        public int DamageMinimum { get; set; }
        public int DamageMaximum { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public virtual ICollection<string> Abilities { get; set; }
        public int GoldCost { get; set; }
        public virtual ICollection<ResourceCostDto> ResourceCosts { get; set; }
        public int BaseGrowth { get; set; }
    }
}
