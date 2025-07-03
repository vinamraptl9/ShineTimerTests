using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineTimerTests.POMPages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Login page locators

        private IWebElement loginText => _driver.FindElement(By.LinkText("Login"));
        private IWebElement txtUserName => _driver.FindElement(By.Id("Input_Email"));
        private IWebElement txtPassword => _driver.FindElement(By.Id("Input_Password"));
        private IWebElement btnLogin => _driver.FindElement(By.Id("login-submit"));
        private IWebElement validationError => _driver.FindElement(By.CssSelector(".validation-summary-errors li"));
        private IWebElement emailValidationError => _driver.FindElement(By.Id("Input_Email-error"));
        private IWebElement passwordValidationError => _driver.FindElement(By.Id("Input_Password-error"));

        // Login page actions
        public void ClickLogin()
        {
            loginText.ClickElement();
        }

        public void Login(string username, string password)
        {
            txtUserName.EnterText(username);
            txtPassword.EnterText(password);
            btnLogin.ClickElement();
        }

        public string GetValidationError()
        {
            return validationError.Text;
        }

        public string GetEmailValidationError()
        {
            return emailValidationError.Text;
        }

        public string GetPasswordValidationError()
        {
            return passwordValidationError.Text;
        }

    }
}
