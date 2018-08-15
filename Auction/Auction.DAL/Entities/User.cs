using System.Collections.Generic;

namespace Auction.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Lot> Lots { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}
