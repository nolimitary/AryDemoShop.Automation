using OpenQA.Selenium;
using DemoShop.Infrastructure.DTOs;

namespace DemoShop.Infrastructure.Pages
{
    public class RegisterPage : BasePage
    {
        private By _regLink = By.XPath("//a[@class='ico-register']");
        private By _male = By.XPath("//input[@id='gender-male']");
        private By _fName = By.XPath("//input[@id='FirstName']");
        private By _lName = By.XPath("//input[@id='LastName']");
        private By _email = By.XPath("//input[@id='Email']");
        private By _pass = By.XPath("//input[@id='Password']");
        private By _confirm = By.XPath("//input[@id='ConfirmPassword']");
        private By _regBtn = By.XPath("//input[@id='register-button']");
        private By _success = By.XPath("//div[@class='result']");

        public RegisterPage(IWebDriver driver) : base(driver) { }

        public void Register(UserDTO user)
        {
            Click(_regLink);
            Click(_male);
            Type(_fName, user.FirstName);
            Type(_lName, user.LastName);
            Type(_email, user.Email);
            Type(_pass, user.Password);
            Type(_confirm, user.Password);
            Click(_regBtn);
        }

        public string GetMessage() => FindElement(_success).Text;
    }
}