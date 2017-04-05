using System;
using System.Collections.Generic;
using BJAT.Data.Entities;

namespace BJAT.Data.Repositories
{
    public interface IDealRepository : IRepository<Deal>
    {
        IEnumerable<Deal> GetDealsWithMistakes(Guid userId);
    }
}