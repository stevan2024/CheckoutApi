using CheckoutApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Database
{
    public class PriceRulesDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PricingRulesDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<PricingRulesDBContext>>()))
            {
                // Look for any books.
                if (context.PricingRules.Any())
                {
                    return;   // Data was already seeded
                }

                context.PricingRules.AddRange(
                    new PricingRule
                    {
                        PricingRuleId = 1,
                        ItemId = "A",
                        SpecialUnitDescription = "3 for 130",
                        Price = 50,
                        SpecialGroupPrice = 130,
                        SpecialUnitAmount = 3
                    },
                     new PricingRule
                     {
                         PricingRuleId = 2,
                         ItemId = "B",
                         SpecialUnitDescription = "2 for 45",
                         Price = 30,
                         SpecialGroupPrice = 45,
                         SpecialUnitAmount = 2
                     },
                     new PricingRule
                     {
                         PricingRuleId = 3,
                         ItemId = "C",
                         SpecialUnitDescription = "none",
                         Price = 20,
                         SpecialGroupPrice = 0,
                         SpecialUnitAmount = 0
                     },
                      new PricingRule
                      {
                          PricingRuleId = 4,
                          ItemId = "D",
                          SpecialUnitDescription = "none",
                          Price = 15,
                          SpecialGroupPrice = 0,
                          SpecialUnitAmount = 0
                      }

                    );

                context.SaveChanges();
            }
        }
    }
}