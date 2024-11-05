
using CheckoutApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Database
{
    public class PricingRulesDBContext : DbContext
    {
        public PricingRulesDBContext(DbContextOptions<PricingRulesDBContext> options)
        : base(options) { }

        public DbSet<PricingRule> PricingRules { get; set; }

    }
}
