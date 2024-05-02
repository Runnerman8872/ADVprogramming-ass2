using Microsoft.EntityFrameworkCore;

namespace ADVprogramming_ass2.Model
{
    public class AppDBContext : DbContext
    {
        //represents the items model
        public DbSet<ItemsOnSaleModel> Item { get; set; }

        //represents the user model
        public DbSet<UserModel> User_Name { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Item> OrderItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
