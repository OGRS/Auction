using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using System;

namespace Auction.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AuctionContext db;
        private EFGenericRepository<Category> categoryRepository;
        private EFGenericRepository<Lot> lotRepository;
        private EFGenericRepository<User> userRepository;
        private EFGenericRepository<Bet> betRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new AuctionContext(connectionString);
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new EFGenericRepository<Category>(db);
                return categoryRepository;
            }
        }

        public IGenericRepository<Lot> Lots
        {
            get
            {
                if (lotRepository == null)
                    lotRepository = new EFGenericRepository<Lot>(db);
                return lotRepository;
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new EFGenericRepository<User>(db);
                return userRepository;
            }
        }

        public IGenericRepository<Bet> Bets
        {
            get
            {
                if (betRepository == null)
                    betRepository = new EFGenericRepository<Bet>(db);
                return betRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
