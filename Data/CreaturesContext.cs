using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes_3_Creatures.Models;
using Microsoft.EntityFrameworkCore;

namespace Heroes_3_Creatures
{
    public class CreaturesContext : DbContext
    {
        public CreaturesContext(DbContextOptions<CreaturesContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAMIL-PC;Initial Catalog=Heroes 3 Creatures;Trusted_Connection=Yes");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreatureAbility>().HasKey(ca => new {ca.CreatureId, ca.AbilityId });

            modelBuilder.Entity<CreatureAbility>()
                .HasOne<Creature>(ca => ca.Creature)
                .WithMany(c => c.CreatureAbilities)
                .HasForeignKey(ca => ca.CreatureId);

            modelBuilder.Entity<CreatureAbility>()
                .HasOne<Ability>(ca => ca.Ability)
                .WithMany(c => c.CreatureAbilities)
                .HasForeignKey(ca => ca.AbilityId);
        }

        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Fraction> Fractions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceCost> ResourceCosts { get; set; }
        public DbSet<CreatureAbility> CreatureAbilities { get; set; }

    }
}
