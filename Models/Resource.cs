using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Heroes_3_Creatures.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ResourceCost> ResourceCost { get; set; }
    }
}