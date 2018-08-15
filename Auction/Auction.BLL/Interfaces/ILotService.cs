using Auction.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Interfaces
{
    public interface ILotService
    {
        IEnumerable<LotDTO> GetLots();
        IEnumerable<LotDTO> GetLotsByCategory(int id);
        //IEnumerable<LotDTO> Search(); //?????
        LotDTO GetLotById(int id);
        //void CreateLot(LotDTO lot);
        //void DeleteLot(LotDTO lot);
        //void UpdateLot(LotDTO lot);
        void Dispose();
    }
}
