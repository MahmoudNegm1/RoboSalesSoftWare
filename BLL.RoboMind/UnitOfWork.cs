using DAL.RoboSalesSoftWare.ApplicationDbContext;
using DAL.RoboSalesSoftWare.IRepositories;
using DAL.RoboSalesSoftWare.Repositories;

namespace BLL.RoboMind
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IVegetablesRepo VegetablesRepo { get; private set; }
        public IReceiptRepo ReceiptRepo { get; private set; }
        public IMarketDataRepo MarketDataRepo { get; private set; }
        public IUserRepo UserRepo { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;

            VegetablesRepo = new VegetablesRepo(context);
            ReceiptRepo = new ReceiptRepo(context);
            MarketDataRepo = new MarketRepo(context);
            UserRepo = new UserRepo(context);
        }



    }


}
