using System;
using System.Collections.Generic;
using BJAT.Data.Entities;

namespace BJAT.Data.Repositories
{
    public interface IHandRepository : IRepository<Hand>
    {
        IEnumerable<Hand> GetHandsByDeal(Guid dealId);
    }
}