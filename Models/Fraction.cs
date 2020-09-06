using System.ComponentModel.DataAnnotations;

namespace Heroes_3_Creatures.Models
{
    public class Fraction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}