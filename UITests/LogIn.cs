using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.POM;
using System;


namespace LogIn.UITest
{
    public class Tests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Dispose();
        }

        [Test]
        public void CheckValidChangeName()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            var accountSetting = new AccountSetting(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            var home = new HomePage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("k.galchenko27@gmail.com")
                .InputPasswordField("Nelegal95!")
                .ClickLogIn();
            accountSetting.GoToAccountSetting()
                .ChengeGeneral()
                .ChangeFirstName("kostyantyn")
                .SaveChange()
                .GoToMainPage();
            var homePage = new HomePage(_webDriver);
            string actualResult = homePage.CheckATryLogIn;
            Assert.AreEqual(expected: "Welcome back kostyantyn! How can we help?", actual: actualResult);
        }

        [TestCase("596af73a33@emailnax.com", "!!!!!!!!!!!!!!")]
        [TestCase("WrongEmail@s.comemailnax.com", "1234567890Qe_d")]
        public void LoginWithInvalidLogginAndPass(string mail, string password)
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField(mail)
                .InputPasswordField(password)
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessage();
            Assert.AreEqual(expected: "Please enter a correct email and password.", actualResultMessage);
        }

        [TestCase("", "")]
        public void LoginWithEmptyPasswordAndEmail(string mail, string password)
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField(mail)
                .InputPasswordField(password)
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessageAboutPassword() + signInPage.GetErrorMessageAboutMail();
            Assert.AreEqual(expected: "RequiredRequired", actualResultMessage);
        }

        [TestCase("888888883@egmail.com", "")]
        public void LoginWithEmptyPassword(string mail, string password)
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField(mail)
                .InputPasswordField(password)
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessageAboutPassword();
            Assert.AreEqual(expected: "Required", actualResultMessage);
        }

        [Test]
        public void LoginWithValidLogginAndPass()
        {
            var signInPage = new SignInPage(_webDriver);
            var home = new HomePage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("k.galchenko27@gmail.com")
                .InputPasswordField("Nelegal95!")
                .ClickLogIn();
            var actualResultMessage = home.CheckATryLogIn;
            Assert.AreEqual(expected: "Welcome back kostyantyn! How can we help?", actualResultMessage);
        }

        [Test]
        public void LoginWithTheEmptyEmail()
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputMailField("")
                .InputPasswordField("___________43")
                .ClickLogIn();
            var actualResultMessage = signInPage.GetErrorMessageAboutMail();
            Assert.AreEqual(expected: "Required", actualResultMessage);
        }
    }
}