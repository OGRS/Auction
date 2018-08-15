using Auction.DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Auction.DAL.EF
{
    public class AuctionContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }

        static AuctionContext() 
            => Database.SetInitializer(new StoreDbInitializer());

        public AuctionContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            => modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    }
}
