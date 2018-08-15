using Auction.DAL.Entities;
using System;

namespace Auction.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Lot> Lots { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Bet> Bets { get; }
        void Save();
    }
}
