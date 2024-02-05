using DAL.RoboSalesSoftWare.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare.ApplicationDbContext
{
    public  class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<VegatablesType> VegatablesTypes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetails> ReceiptDetailss { get; set; }
        public DbSet<MarketData> MarketDatas { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
