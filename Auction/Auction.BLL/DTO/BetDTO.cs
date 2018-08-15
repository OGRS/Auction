using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.DTO
{
    public class BetDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public int LotId { get; set; }

        public DateTime Date { get; set; } 
    }
}
