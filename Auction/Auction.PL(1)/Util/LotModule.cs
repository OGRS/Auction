using Auction.BLL.Interfaces;
using Auction.BLL.Services;
using Ninject.Modules;

namespace Auction.PL.Util
{
    public class LotModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILotService>().To<LotService>();
        }
    }
}