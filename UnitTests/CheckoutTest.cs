using Checkout.Database;
using CheckoutApi.Models;
using CheckoutApi.Repository;
using CheckoutApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CheckoutApi.UnitTests
{

    [TestClass]
    public class CheckoutTest
    {
        private List<Item> _items = new();
        private List<PricingRule> _pricingRules = new();


        Mock<IItemsRepository> _mockItemsRepository = new();

        public void Checkout() { }


        [TestMethod] 
        public void Test() {
            //Arrange

            CheckoutTestHelper testHelper = new CheckoutTestHelper();

            IPricing pricing = new Pricing(testHelper.GetPricingRules());
            IItemsRepository itemsRepository = new ItemsRepositoryTest([]);

            ICheckout checkout = new Services.Checkout(pricing, itemsRepository);

            Assert.IsNotNull(checkout);
            Assert.IsTrue(checkout.Scan("A") == 50);

            //Assert
            Assert.IsTrue(checkout.Price("") == 0);
            Assert.IsTrue(checkout.Price("A") == 50);
            Assert.IsTrue(checkout.Price("AB") == 80);
            Assert.IsTrue(checkout.Price("CDBA") == 115);

            Assert.IsTrue(checkout.Price("AA") == 100);
            Assert.IsTrue(checkout.Price("AAA") == 130);
            Assert.IsTrue(checkout.Price("AAAA") == 180);
            Assert.IsTrue(checkout.Price("AAAAA") == 230);
            Assert.IsTrue(checkout.Price("AAAAAA") == 260);

            Assert.IsTrue(checkout.Price("AAAB") == 160);
            Assert.IsTrue(checkout.Price("AAABB") == 175);
            Assert.IsTrue(checkout.Price("AAABBD") == 190);
            Assert.IsTrue(checkout.Price("DABABA") == 190);

            Assert.IsTrue(checkout.Price("AAABAAAA") == 340);

            checkout.RemoveAllItems();

            Assert.IsTrue(checkout.GetTotal() == 0);
            Assert.IsTrue(checkout.Scan("A") == 50);
            Assert.IsTrue(checkout.Scan("B") == 80);
            Assert.IsTrue(checkout.Scan("A") == 130);
            Assert.IsTrue(checkout.Scan("A") == 160);
            Assert.IsTrue(checkout.Scan("B") == 175);

        }

        [TestMethod]
        public async Task CheckoutRemove_SuccessAsync()
        {
            //Arrange
            CheckoutTestHelper testHelper = new CheckoutTestHelper();

            IPricing pricing = new Pricing(testHelper.GetPricingRules());
            IItemsRepository itemsRepository = new ItemsRepositoryTest([]);

            ICheckout checkout = new Services.Checkout(pricing, itemsRepository);

            //Assert
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.IsTrue(await checkout.RemoveItem("A") == 100);

        }


    }
}
