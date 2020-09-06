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

        public IEnumerable<Creature> GetAllCreatures()
        {
            IEnumerable<Creature> creatures = _context.Creatures
                .Include(c => c.Fraction)
                .Include(c => c.ResourceCosts)
                    .ThenInclude(rc => rc.Resource)
                .Include(c => c.CreatureAbilities)
                    .ThenInclude(ca => ca.Ability);
            return creatures;
        }

        public Creature GetCreatureById(int id)
        {
            //no idea why this needs so many more includes than GetAllCreatures, but without them it completely skips all the nestings related to "upgraded from"
            Creature creature = _context.Creatures
                .Include(c=>c.UpgradedFrom)
                    .ThenInclude(uf=>uf.CreatureAbilities)
                .Include(c => c.UpgradedFrom)
                    .ThenInclude(uf => uf.ResourceCosts)
                .Include(c => c.UpgradedFrom)
                    .ThenInclude(uf => uf.UpgradedFrom)
                        .ThenInclude(ufuf=>ufuf.CreatureAbilities)
                .Include(c => c.UpgradedFrom)
                    .ThenInclude(uf => uf.UpgradedFrom)
                        .ThenInclude(ufuf => ufuf.ResourceCosts)
                .Include(c=>c.Fraction)
                .Include(c => c.ResourceCosts)
                    .ThenInclude(rc => rc.Resource)
                .Include(c => c.CreatureAbilities)
                    .ThenInclude(ca => ca.Ability)
                .FirstOrDefault(c => c.Id == id);
            return creature;
        }
    }
}
