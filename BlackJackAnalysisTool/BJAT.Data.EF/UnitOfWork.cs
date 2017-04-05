using BJAT.Data.EF.Repositories;
using BJAT.Data.Repositories;

namespace BJAT.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _context;
        
        public UnitOfWork(AppContext context)
        {
            _context = context;
            Cards = new CardRepository(_context);
            Hands = new HandRepository(_context);
            Deals = new DealRepository(_context);
            Mistakes = new MistakeRepository(_context);
            Users = new UserRepository(_context);
        }

        public ICardRepository Cards { get; }
        public IHandRepository Hands { get; }
        public IDealRepository Deals { get; }
        public IMistakeRepository Mistakes { get; }
        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}