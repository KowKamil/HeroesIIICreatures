using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_3_Creatures.Models
{
    public class CreatureAbility
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }

        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}
