using System;
using BJAT.Common.Enums;
using BJAT.Data.Entities;

namespace BJAT.Data.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetCardById(Guid id);
        Card GetCard(CardValueEnum val, CardSuitEnum suit);
    }
}