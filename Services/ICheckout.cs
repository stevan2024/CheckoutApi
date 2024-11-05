using CheckoutApi.Models;

namespace CheckoutApi.Services
{
    public interface ICheckout
    {
        decimal GetTotal();
        void RemoveAllItems();
        Task<decimal> RemoveItem(string itemId);
        Task<decimal> RecalculateCartTotal();
        decimal Scan(string itemId, bool addItemToCart = true);
        decimal Price(string itemStringList);
        public Task<List<Item>> GetAllItems();
        public CheckoutTotals GetTotals();

    }
}
