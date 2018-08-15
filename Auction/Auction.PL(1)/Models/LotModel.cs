﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.PL.Models
{
    public class LotModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string UserName { get; set; }
        public int NumberOfBets { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}