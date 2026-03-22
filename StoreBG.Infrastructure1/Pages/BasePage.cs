using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoShop.Infrastructure.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public void WaitForPageReady()
        {
            Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            Wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return typeof jQuery == 'undefined' || jQuery.active == 0"));
        }

        protected IWebElement FindElement(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void Click(By locator)
        {
            WaitForPageReady();
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        protected void Type(By locator, string text)
        {
            WaitForPageReady();
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}