using Checkout.Database;
using CheckoutApi.Models;
using CheckoutApi.Repository;

namespace CheckoutApi.Services
{
    public class Pricing:IPricing
    {
        public List<PricingRule> Rules { get; set; }


        public Pricing(IPricingRulesRepository pricingRulesRepository)
        {
            Rules = pricingRulesRepository.GetPricingRules();

        }

        public Pricing(List<PricingRule> priceRulesList)
        {
            Rules = priceRulesList;

        }


        public decimal GetPrice(Item item, int numberOfThisTypeOfItem)
        {
            PricingRule pricingRule = Rules.FirstOrDefault(r => r.ItemId == item.ItemId);

            if (pricingRule == null)
            {
                return 0;
            }

            if (pricingRule.SpecialUnitDescription != "none" && numberOfThisTypeOfItem % pricingRule.SpecialUnitAmount == 0)
            {
                // need to apply discount to this unit to make the discount total correct

                decimal groupPriceUndiscounted = pricingRule.SpecialUnitAmount * pricingRule.Price;
                decimal lastUnitDiscount = groupPriceUndiscounted - pricingRule.SpecialGroupPrice;

                item.AppliedDiscount = lastUnitDiscount;

                decimal newLastUnitPrice = pricingRule.Price - lastUnitDiscount;

                item.AppliedPrice = newLastUnitPrice;

                return newLastUnitPrice;
            }
            else
            {
                item.AppliedPrice = pricingRule.Price;
                return pricingRule.Price;

            }

        }
    }
}
