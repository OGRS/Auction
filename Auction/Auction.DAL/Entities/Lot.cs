using System;
using System.Collections.Generic;

namespace Auction.DAL.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
       
        public int UserId { get; set; }
        public string UserName { get { return User.Name; } }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public ICollection<Bet> Bets { get; set; }
        public int NumberOfBets { get { return Bets.Count; } }

    }
}
