using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
