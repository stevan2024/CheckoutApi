using CheckoutApi.Models;

namespace CheckoutApi.Repository
{
    public interface IItemsRepository
    {
        public Task Add(Item item);

        public Task<List<Item>> GetAllItems();

        public Task RemoveItem(string itemId);

        public Task RemoveAllItems();

        public int GetItemCount(string itemId);

        public CheckoutTotals GetTotals();

        public Task<Item> GetItem(string itemId);
    }
}
