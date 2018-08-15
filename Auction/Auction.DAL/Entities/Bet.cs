using System;

namespace Auction.DAL.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int LotId { get; set; }
        public Lot Lot { get; set; }

        public DateTime Date { get; set; }
    }
}
