using System.Collections.Generic;
using OpenQA.Selenium;
using DemoShop.Infrastructure.DTOs;

namespace DemoShop.Infrastructure.Pages
{
    public class CartPage : BasePage
    {
        private By _books = By.XPath("//ul[@class='top-menu']//a[contains(text(),'Books')]");
        private By _addBtn = By.XPath("//div[@class='item-box'][1]//input[@value='Add to cart']");
        private By _cartLink = By.XPath("//a[@class='ico-cart']");
        private By _rows = By.XPath("//tr[@class='cart-item-row']");
        private By _pName = By.XPath(".//a[@class='product-name']");
        private By _pPrice = By.XPath(".//span[@class='product-unit-price']");
        private By _remove = By.XPath("//input[@name='removefromcart']");
        private By _update = By.XPath("//input[@name='updatecart']");
        private By _terms = By.XPath("//input[@id='termsofservice']");
        private By _checkout = By.XPath("//button[@id='checkout']");

        public CartPage(IWebDriver driver) : base(driver) { }

        public void AddItem()
        {
            Click(_books);
            Click(_addBtn);
        }

        public void GoToCart() => Click(_cartLink);

        public List<ProductDTO> GetItems()
        {
            var list = new List<ProductDTO>();
            foreach (var r in Driver.FindElements(_rows))
            {
                list.Add(new ProductDTO { Name = r.FindElement(_pName).Text, Price = decimal.Parse(r.FindElement(_pPrice).Text) });
            }
            return list;
        }

        public void RemoveItem() { Click(_remove); Click(_update); }
        public void StartCheckout() { Click(_terms); Click(_checkout); }
    }
}