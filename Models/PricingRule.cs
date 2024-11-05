using System.ComponentModel.DataAnnotations;

namespace CheckoutApi.Models
{
    public class PricingRule
    {
        [Key]
        public int PricingRuleId { get; set; }
        public string ItemId { get; set; }
        public decimal Price { get; set; }
        public decimal SpecialGroupPrice { get; set; }
        public decimal SpecialUnitAmount { get; set; }
        public string SpecialUnitDescription { get; set; }




    }
}
