using BLL.RoboMind.AppServices;
using DAL.RoboSalesSoftWare.IRepositories;

namespace BLL.RoboMind
{
    public interface IUnitOfWork
    {

        IVegetablesRepo VegetablesRepo { get; }
        IReceiptRepo ReceiptRepo { get; }
        IMarketDataRepo MarketDataRepo { get; }
        IUserRepo UserRepo { get; }

    }
}
