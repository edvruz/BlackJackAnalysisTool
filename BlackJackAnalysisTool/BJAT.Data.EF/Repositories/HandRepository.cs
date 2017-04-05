using System;
using System.Collections.Generic;
using System.Data.Entity;
using BJAT.Data.Entities;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF.Repositories
{
    public class HandRepository : Repository<Hand>, IHandRepository
    {
        public HandRepository(AppContext context) : base(context)
        {
        }

        public IEnumerable<Hand> GetHandsByDeal(Guid dealId)
        {
            throw new NotImplementedException();
        }
    }
}