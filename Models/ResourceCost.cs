using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Heroes_3_Creatures.Models
{
    public class ResourceCost
    {
        [Key]
        public int Id { get; set; }
        [Required]     
        public int CreatureID { get; set; }
        [Required]
        public int ResourceID { get; set; }

        public Creature Creature { get; set; }
        public Resource Resource { get; set; }
        [Required]
        public int Amount { get; set; }

    }
}
