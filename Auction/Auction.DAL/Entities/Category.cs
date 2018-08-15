using System.Collections.Generic;

namespace Auction.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }

        public ICollection<Lot> Lots { get; set; }
    }
}
