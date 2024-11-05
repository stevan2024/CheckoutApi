using Checkout.Database;
using CheckoutApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace CheckoutApi.Repository
{
    public class PricingRulesRepository : IPricingRulesRepository
    {
        public List<PricingRule> Rules { get; set; }

        public PricingRulesRepository(PricingRulesDBContext pricingRulesDBContext)
        {

            Rules = [.. pricingRulesDBContext.PricingRules];
        }

        public PricingRulesRepository(List<PricingRule> rules)
        {
            Rules = rules;
        }

        public List<PricingRule> GetPricingRules()
        {
            return Rules;
        }
    }
}



