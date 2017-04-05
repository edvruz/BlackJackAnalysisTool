using System;
using BJAT.Data.Repositories;

namespace BJAT.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository Cards { get; }
        IHandRepository Hands { get; }
        IDealRepository Deals { get; }
        IMistakeRepository Mistakes { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}