using Auction.BLL.Interfaces;
using Auction.BLL.Services;
using Ninject.Modules;

namespace Auction.PL.Util
{
    public class CategoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
        }
    }
}