using Auction.BLL.DTO;
using Auction.BLL.Infrastructure;
using Auction.BLL.Interfaces;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Services
{
    public class LotService : ILotService
    {
        private readonly IUnitOfWork Database;

        public LotService(IUnitOfWork uow) => Database = uow;

        public IEnumerable<LotDTO> GetLots()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Lot, LotDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Lot>, List<LotDTO>>(Database.Lots.GetWithInclude
                (l => l.User, l => l.Bets));
        }

        public IEnumerable<LotDTO> GetLotsByCategory(int id)
        {
            if (id == 0)
                throw new ValidationException("id", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Lot, LotDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Lot>, List<LotDTO>>(Database.Lots.GetWithInclude
                (l => l.Category.Id == id, l => l.User, l => l.Bets, l => l.Category));
        }

        public LotDTO GetLotById(int id)
        {
            if (id == 0)
                throw new ValidationException("zero", "");
            var lot = Database.Lots.FindWithInclude(l => l.Id == id, l => l.User, l => l.Bets);
            if (lot == null)
                throw new ValidationException("lot not found", "");

            return new LotDTO { Id = lot.Id, Name = lot.Name, Price = lot.Price, CategoryId = lot.CategoryId,
                                UserName = lot.UserName, Location = lot.Location, NumberOfBets = lot.NumberOfBets,
                                DateStart = lot.DateStart, DateEnd = lot.DateEnd };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
