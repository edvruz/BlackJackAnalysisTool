using System;
using System.Collections.Generic;
using System.Data.Entity;
using BJAT.Data.Entities;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF.Repositories
{
    public class MistakeRepository : Repository<Mistake>, IMistakeRepository
    {
        public MistakeRepository(AppContext context) : base(context)
        {
        }

        public IEnumerable<Mistake> GetMistakesByDeal(Guid dealId)
        {
            throw new NotImplementedException();
        }
    }
}