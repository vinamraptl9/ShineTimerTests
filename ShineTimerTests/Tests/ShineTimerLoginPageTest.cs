using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShineTimerTests.POMPages;
using OpenQA.Selenium.Support.UI;
using AngleSharp.Html;

namespace ShineTimerTests.Tests
{
    public class ShineTimerLoginPageTest:IDisposable
    {
        private readonly IWebDriver _driver;

        public ShineTimerLoginPageTest()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://shinetimer.azurewebsites.net/");
            _driver.Manage().Window.Maximize();
        }


        [Fact]
        public void Login_WithValidCredentials_ShouldRedirectToHomePage()
        {
            
            LoginPage page = new LoginPage(_driver);


            page.ClickLogin();
            page.Login("vinamrapatel543@gmail.com", "Vin@1234");


            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));


            string expectedTitle = "Home - Shine Timer";
            string actualTitle = _driver.Title;

            Assert.Equal(expectedTitle, actualTitle);

        }


        [Fact]
        public void Login_WithInValidCredentials_GivesCredentialsError()
        {
            LoginPage page = new LoginPage(_driver);

            page.ClickLogin();
            page.Login("fakemail@abc.com", "fakepass");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => page.GetValidationError().Length > 0);

            string expectedError = "Invalid login attempt.";
            string actualError = page.GetValidationError();

            Assert.Equal(expectedError, actualError);
        }

        [Fact]
        public void Login_WithEmptyCredentials_ShowsFieldRequiredErrors()
        {
            LoginPage page = new LoginPage(_driver);

            page.ClickLogin();
            page.Login("", "");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver =>
                page.GetEmailValidationError().Length > 0 &&
                page.GetPasswordValidationError().Length > 0
            );

            string expectedEmailError = "The Email field is required.";
            string expectedPasswordError = "The Password field is required.";

            string actualEmailError = page.GetEmailValidationError();
            string actualPasswordError = page.GetPasswordValidationError();

            Assert.Equal(expectedEmailError, actualEmailError);
            Assert.Equal(expectedPasswordError, actualPasswordError);
        }


        [Fact]
        public void Login_WithOnlyEmailCredentials_ShowsPasswordRequiredError()
        {
            LoginPage page = new LoginPage(_driver);

            page.ClickLogin();
            page.Login("Vinamrapatel543@gmail.com", "");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver => page.GetPasswordValidationError().Length > 0);

            
            string expectedPasswordError = "The Password field is required.";

            string actualPasswordError = page.GetPasswordValidationError();

            Assert.Equal(expectedPasswordError, actualPasswordError);
        }

        [Fact]
        public void Login_WithOnlyPasswordCredentials_ShowsEmailRequiredError()
        {
            LoginPage page = new LoginPage(_driver);

            page.ClickLogin();
            page.Login("", "Vin@1234");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver => page.GetEmailValidationError().Length > 0);

            string expectedEmailError = "The Email field is required.";

            string actualEmailError = page.GetEmailValidationError();

            Assert.Equal(expectedEmailError, actualEmailError);
        }

        [Fact]
        public void Login_WithInvalidEmailFormat_ShowsEmailFormatError()
        {
            LoginPage page = new LoginPage(_driver);

            page.ClickLogin();
            page.Login("Vinamrapatel543@.com", "Vin@1234");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver => page.GetEmailValidationError().Length > 0);

            string expectedEmailError = "The Email field is not a valid e-mail address.";

            string actualEmailError = page.GetEmailValidationError();

            Assert.Equal(expectedEmailError, actualEmailError);
        }

        [Fact]
        public void Login_EmailCaseInsensitive_ShouldSucceed()
        {
            LoginPage page = new LoginPage(_driver);
            page.ClickLogin();
            page.Login("VINAMRAPATEL543@GMAIL.COM", "Vin@1234");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => _driver.Title.Contains("Home"));

            string expectedTitle = "Home - Shine Timer";
            string actualTitle = _driver.Title;

            Assert.Equal(expectedTitle, actualTitle);
        }


        [Fact]
        public void Login_WithWhitespaceCredentials_ShouldShowInvalidLoginError()
        {
            LoginPage page = new LoginPage(_driver);
            page.ClickLogin();
            page.Login("  vinamrapatel543@gmail.com  ", "  Vin@1234  ");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => page.GetValidationError().Length > 0);

            string expectedError = "Invalid login attempt.";
            string actualError = page.GetValidationError();

            Assert.Equal(expectedError, actualError);
        }



        public void Dispose()
        {
            _driver.Quit();
        }

    }
}
