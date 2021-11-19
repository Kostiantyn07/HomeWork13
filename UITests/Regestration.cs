using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.POM;
using System;

namespace Registration.UITest
{
    class Registration
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _webDriver = new ChromeDriver(options);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Dispose();
        }

        [Test]
        public void RegistrationWitfValidData()
        {
            string name = "Kostya";
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(name)
                .InputLastName("Kostya")
                .InputEmail(Helper.RandomEmailUser())
                .InputPassword("Nelegal95!")
                .InputConfirmPassword("Nelegal95!")
                .InputPhoneNumber("1234567890")
                .ClickNextButton();

            registrationPage.InputCompanyName("Nelegal")
                .InputCompanyWebSite("Nelegal.com")
                .InputCompanyAddress("2453 Lombard St, San Francisco, CA 94123, USA")
                .InputCompanyIndustry(4)
                .ClickOnFinishRegistration();

            Assert.AreEqual(expected: $"Welcome {name}! How can we help?", home.CheckATryLogIn);
        }

        [TestCase("Kostya", "Gall", "Nelegal95!", "Nelegal95!", "1234567890")]
        public void RegistrationWithInValidEmail(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail("name")
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutEmail();

            Assert.AreEqual(expected: "Invalid Email", actualResultat);
        }

        [TestCase("Kostya", "Gall", "nelegal95!", "nelegal95!", "1235678903")]
        public void RegistrationWithInValidPasswordUppercase(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.RandomEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordUpperCase();

            Assert.AreEqual(expected: "Invalid password format At least one capital letter", actualResultat);
        }

        [TestCase("Kostya", "Gall", "Qe_d", "Qe_d", "1234567890")]
        [TestCase("Kostya", "Gall", "Nelegal95Nelegal95Nelegal95", "Nelegal95Nelegal95Nelegal95", "1234567890")]
        [TestCase("K", "K", "K_f", "K_f", "1234567890")]
        public void RegistrationWithInValidPasswordLenght(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.RandomEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordLenght();

            Assert.AreEqual(expected: "Invalid password format From 8 to 25 characters", actualResultat);
        }

        [TestCase("K", "G", "Nelegal95", "Nelegal95", "1234567890")]
        public void RegistrationWithInValidPasswordSymbol(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);          
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.RandomEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword() + " " + registrationPage.errorTextAboutPasswordMarks();

            Assert.AreEqual(expected: "Invalid password format At least one special character such as an exclamation mark", actualResultat);
        }

        [TestCase("K", "", "Nelegal95!", "Nelegal95!", "1231231234")]
        public void RegistrationWithEmptyLastName(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.RandomEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutLastName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("", "K", "Nelegal95!", "Nelegal95!", "1234567890")]
        public void RegistrationWithEmptyFirstName(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.RandomEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutFirstName();

            Assert.AreEqual(expected: "Required", actualResultat);
        }

        [TestCase("Kostya", "Gall", "", "Nelegal95!", "1234567890")]
        public void RegistrationWithEmptyPasword(string firstName, string lastName, string password, string confirmPassword, string phone)
        {
            var registrationPage = new RegistrationPages(_webDriver);
            var home = new HomePage(_webDriver);
            registrationPage.GoToRegistrationPages()
                .InputFirstName(firstName)
                .InputLastName(lastName)
                .InputEmail(Helper.RandomEmailUser())
                .InputPassword(password)
                .InputConfirmPassword(confirmPassword)
                .InputPhoneNumber(phone)
                .ClickNextButton();
            var actualResultat = registrationPage.errorTextAboutPassword();

            Assert.AreEqual(expected: "Invalid password format", actualResultat);
        }
    }
}
