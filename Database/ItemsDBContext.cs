
using CheckoutApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Database
{
    public class ItemsDBContext : DbContext
    {
        public ItemsDBContext(DbContextOptions<ItemsDBContext> options)
        : base(options) { }

        public DbSet<Item> Items { get; set; }

    }
}
