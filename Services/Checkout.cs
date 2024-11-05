using CheckoutApi.Models;
using CheckoutApi.Repository;
using System.Xml.Linq;

namespace CheckoutApi.Services
{
    public class Checkout : ICheckout
    {
        private decimal _total;
        private IItemsRepository _itemsRepository;
        private IPricing _pricing;


        public Checkout(IPricing pricing, IItemsRepository itemsRepository)
        {

            _pricing = pricing;
            _itemsRepository = itemsRepository;
        }

        public decimal GetTotal()
        {
            return _total;
        }

        public void RemoveAllItems()
        {
            _total = 0;
            _itemsRepository.RemoveAllItems();
        }

        public async Task<decimal> RemoveItem(string itemId)
        {
            await _itemsRepository.RemoveItem(itemId);

            await RecalculateCartTotal();

            return _total;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _itemsRepository.GetAllItems();

        }

        public async Task<decimal> RecalculateCartTotal()
        {
            _total = 0;

            var items = await _itemsRepository.GetAllItems();

            foreach (var item in items)
            {
                Scan(item.ItemId, false);

            }
            return _total;

        }

        public CheckoutTotals GetTotals()
        {
            CheckoutTotals totals = new CheckoutTotals();

            return _itemsRepository.GetTotals();

        }


        public decimal Scan(string itemId, bool addItemToCart = true)
        {
            //CreateItem
            Item itemToAdd = new Item { ItemId = itemId, Name = itemId };

            // get count of number of this type of item in list
            int numberOfThisTypeOfItem = _itemsRepository.GetItemCount(itemId);

            if (addItemToCart)
            {
                numberOfThisTypeOfItem++;
            }

            // look up item in pricing list
            decimal price = _pricing.GetPrice(itemToAdd, numberOfThisTypeOfItem);

            // create item and add item to list
            if (addItemToCart)
            {
                _itemsRepository.Add(itemToAdd);
            }

            // update the total
            _total = _total + price;

            return _total;
        }

        public decimal Price(string itemStringList)
        {

            RemoveAllItems();
            //var itemNames = itemStringList.Split(",");
            Char[] charArray = itemStringList.ToUpper().ToCharArray();


            foreach (var character in charArray)
            {
                Scan(character.ToString());

            }
            return _total;

        }


    }
}
