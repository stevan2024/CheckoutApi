using Checkout.Database;
using CheckoutApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckoutApi.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private ItemsDBContext _itemsDBContext;


        public ItemsRepository(ItemsDBContext itemsDBContext)
        {
            _itemsDBContext = itemsDBContext;
        }

        public async Task Add(Item item)
        {
            _itemsDBContext.Add(item);
            await _itemsDBContext.SaveChangesAsync();
        }

        public CheckoutTotals GetTotals()
        {

            CheckoutTotals totals = new CheckoutTotals();

            var totalPrice = _itemsDBContext.Items.Sum(a => a.AppliedPrice);

            var totalSavings = _itemsDBContext.Items.Sum(a => a.AppliedDiscount);

            totals.TotalSavings = totalSavings;
            totals.Total = totalPrice;

            return totals;

        }

        public async Task<List<Item>> GetAllItems()
        {

            return await _itemsDBContext.Items.OrderBy(x => x.ID).ToListAsync();

        }

        public async Task<Item> GetItem(string itemId)
        {
            var item = await _itemsDBContext.Items.FirstOrDefaultAsync(x => x.ItemId == itemId);
            return item;
        }

        public async Task RemoveItem(string itemId)
        {
            var item = _itemsDBContext.Items.FirstOrDefault(x => x.ItemId == itemId);

            if (item != null)
            {
                _itemsDBContext.Items.Remove(item);
            }

            await _itemsDBContext.SaveChangesAsync();
        }

        public async Task RemoveAllItems()
        {

            foreach (var item in _itemsDBContext.Items)
            {
                _itemsDBContext.Items.Remove(item);
            }
            await _itemsDBContext.SaveChangesAsync();

        }

        public int GetItemCount(string itemId)
        {
            int numberOfThisTypeOfItem = _itemsDBContext.Items.Where(x => x.ItemId == itemId).Count();
            return numberOfThisTypeOfItem;
        }


    }
}
