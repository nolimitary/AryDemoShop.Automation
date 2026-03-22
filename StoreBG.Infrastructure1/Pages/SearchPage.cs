using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using DemoShop.Infrastructure.DTOs;
using SeleniumExtras.WaitHelpers;

namespace DemoShop.Infrastructure.Pages
{
    public class SearchPage : BasePage
    {
        private By _box = By.XPath("//input[@id='small-searchterms']");
        private By _btn = By.XPath("//input[@value='Search']");

        // Indestructible XPaths
        private By _adv = By.XPath("//input[contains(@id, 'adv') or contains(@id, 'As')]");
        private By _sub = By.XPath("//input[contains(@id, 'isc') or contains(@id, 'Isc')]");
        private By _item = By.XPath("//div[@class='product-item']");

        public SearchPage(IWebDriver driver) : base(driver) { }

        public void Search(SearchDTO dto)
        {
            Type(_box, dto.SearchTerm);
            Click(_btn); 
            if (dto.IsAdvancedSearch)
            {
                Click(_adv);

                By dynamicCat = By.XPath($"//select[option[contains(text(), '{dto.Category}')]]");

                var catElement = Wait.Until(ExpectedConditions.ElementIsVisible(dynamicCat));
                var dropdown = new SelectElement(catElement);
                dropdown.SelectByText(dto.Category);

                Click(_sub);

                var buttons = Driver.FindElements(By.XPath("//input[@value='Search']"));
                if (buttons.Count > 1)
                {
                    buttons[1].Click();
                }
                else
                {
                    buttons[0].Click();
                }
            }
        }

        public int ResultCount() => Driver.FindElements(_item).Count;
    }
}