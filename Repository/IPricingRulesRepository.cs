namespace CheckoutApi.Repository
{
    using CheckoutApi.Models;


    public interface IPricingRulesRepository
    {
        public  List<PricingRule> GetPricingRules();
    }
}
