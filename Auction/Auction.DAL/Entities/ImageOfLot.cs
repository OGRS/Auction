namespace Auction.DAL.Entities
{
    class ImageOfLot
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int LotId { get; set; }
        public Lot Lot { get; set; }
    }
}
