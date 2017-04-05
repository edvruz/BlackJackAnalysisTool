using System;
using System.Collections.Generic;
using System.Data.Entity;
using BJAT.Data.Entities;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF.Repositories
{
    public class DealRepository : Repository<Deal>, IDealRepository
    {
        public DealRepository(AppContext context) : base(context)
        {
        }

        public IEnumerable<Deal> GetDealsWithMistakes(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}