using Heroes_3_Creatures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_3_Creatures.Data
{
    public class SQLCreaturesRepo : ICreaturesRepo
    {
        private readonly CreaturesContext _context;

        public SQLCreaturesRepo(CreaturesContext context)
        {
            _context = context;
        }

        public IEnumerable<Creature> Get(int? id, int? tier, string name, string fractionName)
        {
            IEnumerable<Creature> creatures = _context.Creatures
                .Include(c => c.UpgradedFrom)
                    .ThenInclude(uf => uf.CreatureAbilities)
                .Include(c => c.UpgradedFrom)
                    .ThenInclude(uf => uf.ResourceCosts)
                .Include(c => c.UpgradedFrom)
                    .ThenInclude(uf => uf.UpgradedFrom)
                        .ThenInclude(ufuf => ufuf.CreatureAbilities)
                .Include(c => c.UpgradedFrom)
                    .ThenInclude(uf => uf.UpgradedFrom)
                        .ThenInclude(ufuf => ufuf.ResourceCosts)
                .Include(c => c.Fraction)
                .Include(c => c.ResourceCosts)
                    .ThenInclude(rc => rc.Resource)
                .Include(c => c.CreatureAbilities)
                    .ThenInclude(ca => ca.Ability)
                .Where(c => !id.HasValue || c.Id == id)
                .Where(c => !tier.HasValue || c.Tier == tier)
                .Where(c => name == null || c.Name == name)
                .Where(c => fractionName == null || c.Fraction.Name == fractionName);          
            return creatures;
        }
    }
}
