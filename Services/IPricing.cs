using CheckoutApi.Models;

namespace CheckoutApi.Services
{
    public interface IPricing
    {
        public decimal GetPrice(Item item, int numberOfThisTypeOfItem);
    }
}
