using System.Data.Entity;
using BJAT.Data.Entities;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(AppContext context) : base(context)
        {
        }
    }
}