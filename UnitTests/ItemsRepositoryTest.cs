using CheckoutApi.Models;
using CheckoutApi.Repository;

namespace CheckoutApi.UnitTests
{
    public class ItemsRepositoryTest : IItemsRepository
    {
        List<Item> _items;

        public ItemsRepositoryTest(List<Item> items)
        {
            _items = items;
        }

        public Task Add(Item item)
        {
            if (item != null)
            {
                _items.Add(item);
            }

            return Task.FromResult<object>(0);
        }

        public Task<List<Item>> GetAllItems()
        {

            return Task.FromResult<List<Item>>(_items);
        }

        public Task<Item> GetItem(string itemId)
        {

            var item = _items.FirstOrDefault(x => x.ItemId == itemId);

            if (item != null)
            {
                return Task.FromResult(item);
            }

            return Task.FromResult<Item>(item);
        }

        public int GetItemCount(string itemId)
        {
            return _items.Where(x => x.ItemId == itemId).Count();
        }

        public CheckoutTotals GetTotals()
        {
            CheckoutTotals totals = new CheckoutTotals();

            var totalPrice = _items.Sum(a => a.AppliedPrice);

            var totalSavings = _items.Sum(a => a.AppliedDiscount);

            totals.TotalSavings = totalSavings;
            totals.Total = totalPrice;


            return totals;
        }

        public Task RemoveAllItems()
        {
            _items.Clear();

            return Task.FromResult<object>(0);

        }

        public Task RemoveItem(string itemId)
        {
            var item = _items.FirstOrDefault(x => x.ItemId == itemId);

            if (item != null)
            {
                _items.Remove(item);
            }

            return Task.FromResult<object>(0);
        }
    }
}
