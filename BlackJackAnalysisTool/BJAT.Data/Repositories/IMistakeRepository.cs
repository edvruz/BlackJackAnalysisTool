using System;
using System.Collections.Generic;
using BJAT.Data.Entities;

namespace BJAT.Data.Repositories
{
    public interface IMistakeRepository : IRepository<Mistake>
    {
        IEnumerable<Mistake> GetMistakesByDeal(Guid dealId);
    }
}