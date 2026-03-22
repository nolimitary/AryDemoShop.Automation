using OpenQA.Selenium;
using DemoShop.Infrastructure.DTOs;

namespace DemoShop.Infrastructure.Pages
{
    public class LoginPage : BasePage
    {
        private By _loginLink = By.XPath("//a[@class='ico-login']");
        private By _emailInput = By.XPath("//input[@id='Email']");
        private By _passwordInput = By.XPath("//input[@id='Password']");
        private By _loginBtn = By.XPath("//input[@value='Log in']");
        private By _errorMsg = By.XPath("//div[contains(@class,'validation-summary-errors')]");
        private By _headerEmail = By.XPath("//div[@class='header-links']//a[@class='account']");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Login(UserDTO user)
        {
            Click(_loginLink);
            Type(_emailInput, user.Email);
            Type(_passwordInput, user.Password);
            Click(_loginBtn);
        }

        public string GetUserEmail() => FindElement(_headerEmail).Text;
        public string GetError() => FindElement(_errorMsg).Text;
    }
}