using System;
using System.Data.Entity;
using BJAT.Common.Enums;
using BJAT.Data.Entities;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(AppContext context) : base(context)
        {
        }

        public Card GetCardById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Card GetCard(CardValueEnum val, CardSuitEnum suit)
        {
            throw new NotImplementedException();
        }
    }
}