using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Heroes_3_Creatures.Models
{
    public class Creature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Fraction Fraction { get; set; }
        public Creature UpgradedFrom { get; set; }
        [Required]
        public int Tier { get; set; }
        [Required]
        public int Attack { get; set; }
        [Required]
        public int Defense { get; set; }
        [Required]
        public int Shots { get; set; }
        [Required]
        public int DamageMinimum { get; set; }
        [Required]
        public int DamageMaximum { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        public ICollection<CreatureAbility> CreatureAbilities { get; set; }
        [Required]
        public int GoldCost { get; set; }
        [Required]
        public ICollection<ResourceCost> ResourceCosts { get; set; }
        [Required]
        public int BaseGrowth { get; set; }
    }
}
