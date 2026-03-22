using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DemoShop.Infrastructure.Pages;

namespace DemoShop.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected LoginPage LoginP;
        protected RegisterPage RegP;
        protected CartPage CartP;
        protected SearchPage SearchP;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            LoginP = new LoginPage(Driver);
            RegP = new RegisterPage(Driver);
            CartP = new CartPage(Driver);
            SearchP = new SearchPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}