using Checkout.Database;
using CheckoutApi.Models;
using CheckoutApi.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;

namespace CheckoutApi.UnitTests
{
    public class CheckoutTestHelper
    {
       

        public List<PricingRule> GetPricingRules()
        {

            List<PricingRule> pricingRules = new List<PricingRule>();

            pricingRules.Add(
                new PricingRule
                {
                    PricingRuleId = 1,
                    ItemId = "A",
                    SpecialUnitDescription = "3 for 130",
                    Price = 50,
                    SpecialGroupPrice = 130,
                    SpecialUnitAmount = 3
                });


            pricingRules.Add(
                new PricingRule
                {
                    PricingRuleId = 2,
                    ItemId = "B",
                    SpecialUnitDescription = "2 for 45",
                    Price = 30,
                    SpecialGroupPrice = 45,
                    SpecialUnitAmount = 2
                });


            pricingRules.Add(
                new PricingRule
                {
                    PricingRuleId = 3,
                    ItemId = "C",
                    SpecialUnitDescription = "none",
                    Price = 20,
                    SpecialGroupPrice = 0,
                    SpecialUnitAmount = 0
                });

            pricingRules.Add(
                new PricingRule
                {
                    PricingRuleId = 4,
                    ItemId = "D",
                    SpecialUnitDescription = "none",
                    Price = 15,
                    SpecialGroupPrice = 0,
                    SpecialUnitAmount = 0
                });

            return pricingRules;

        }


    }
}
