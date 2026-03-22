using NUnit.Framework;
using DemoShop.Infrastructure.Factories;

namespace DemoShop.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        /// <summary>
        /// Steps: 1. Add book. 2. Go to cart.
        /// Expected Result: DTO matches expected book.
        /// </summary>
        [Test]
        public void Cart_Add_MatchDTO()
        {
            CartP.AddItem(); CartP.GoToCart();
            var items = CartP.GetItems();
            Assert.Multiple(() => {
                Assert.That(items.Count, Is.AtLeast(1), "Cart empty.");
                Assert.That(items[0], Is.EqualTo(ProductFactory.GetExpectedBook()), "DTO mismatch.");
            });
        }

        /// <summary>
        /// Steps: 1. Add item. 2. Remove it.
        /// Expected Result: Cart is empty.
        /// </summary>
        [Test]
        public void Cart_Remove_Empty()
        {
            CartP.AddItem(); CartP.GoToCart(); CartP.RemoveItem();
            Assert.That(Driver.PageSource, Does.Contain("empty"), "Cart not empty.");
        }

        /// <summary>
        /// Steps: 1. Login. 2. Add item. 3. Checkout.
        /// Expected Result: Redirect to checkout.
        /// </summary>
        [Test]
        public void Cart_Checkout_Redirect()
        {
            LoginP.Login(UserFactory.CreateValidUser());
            CartP.AddItem(); CartP.GoToCart(); CartP.StartCheckout();
            Assert.That(Driver.Url, Does.Contain("checkout"), "Not in checkout.");
        }

        /// <summary>
        /// Steps: 1. Anonymous checkout.
        /// Expected Result: Redirect to login.
        /// </summary>
        [Test]
        public void Cart_Anon_LoginPrompt()
        {
            CartP.AddItem(); CartP.GoToCart(); CartP.StartCheckout();
            Assert.That(Driver.Url, Does.Contain("login"), "No login prompt.");
        }
    }
}