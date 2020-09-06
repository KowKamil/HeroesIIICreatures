using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Heroes_3_Creatures.Models
{
    public class Ability
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AbilityText { get; set; }
        public ICollection<CreatureAbility> CreatureAbilities { get; set; }
    }
}