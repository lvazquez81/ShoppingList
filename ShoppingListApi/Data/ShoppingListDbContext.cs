using Microsoft.EntityFrameworkCore;

namespace ShoppingListApi.Data
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyItem> Items { get; set; }
    }
}
