using Heroes_3_Creatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_3_Creatures
{
    public interface ICreaturesRepo
    {
        IEnumerable<Creature> Get(int? id, int? tier, String name, String fraction);
    }
}
