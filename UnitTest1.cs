using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HomeWork13
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        { 
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://newbookmodels.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Registration()
        {
            IWebElement singUp = driver.FindElement(By.ClassName("Navbar__signUp--12ZDV"));
            singUp.Click();
            IWebElement userName = driver.FindElement(By.CssSelector("[name='first_name']"));
            userName.SendKeys("Kostya");
            IWebElement userLastName = driver.FindElement(By.CssSelector("[name='last_name']"));
            userLastName.SendKeys("Nelegal");
            IWebElement email = driver.FindElement(By.CssSelector("[name='email']"));
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            email.SendKeys("newMail" + name + "@test.com");
            IWebElement password = driver.FindElement(By.CssSelector("[name='password']"));
            password.SendKeys("Nelegal95!");
            IWebElement passwordConfirm = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            passwordConfirm.SendKeys("Nelegal95!");
            IWebElement phone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            phone.SendKeys("1234567890");
            IWebElement next = driver.FindElement(By.CssSelector("[type='submit']"));
            next.Click();
            IWebElement companyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            companyName.SendKeys("NELEGAL");
            IWebElement companyWebSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            companyWebSite.SendKeys("galnelegal.com");
            string companyLocation = "2453 Lombard St, San Francisco, CA 94123, USA";
            IWebElement locationField = driver.FindElement(By.CssSelector("input[name=\"location\"]"));
            locationField.SendKeys(companyLocation.ToString());
            Thread.Sleep(1500);
            locationField.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            locationField.SendKeys(Keys.Enter);
            IWebElement industry = driver.FindElement(By.CssSelector("[name='industry']"));
            industry.Click();
            Thread.Sleep(1500);
            industry.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            industry.SendKeys(Keys.Enter);
            IWebElement Finish = driver.FindElement(By.CssSelector("[type='submit']"));
            Finish.Click();
            Assert.Pass();
        }

        [Test]
        public void Authorization()
        {
            IWebElement logIn = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logIn.Click();
            IWebElement logInEmail = driver.FindElement(By.CssSelector("[type='email']"));
            logInEmail.SendKeys("newMail02112021210939@test.com");
            IWebElement logInPassword = driver.FindElement(By.CssSelector("[name='password']"));
            logInPassword.SendKeys("Nelegal95!");
            IWebElement Finish = driver.FindElement(By.CssSelector("[type='submit']"));
            Finish.Click();
            Assert.Pass();
        }

        [Test]
        public void SettingsProfile()
        {
            IWebElement logIn = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logIn.Click();
            IWebElement logInEmail = driver.FindElement(By.CssSelector("[type='email']"));
            logInEmail.SendKeys("k.galchenko27@gmail.com");
            IWebElement logInPassword = driver.FindElement(By.CssSelector("[name='password']"));
            logInPassword.SendKeys("Nelegal95!");
            IWebElement Finish = driver.FindElement(By.CssSelector("[type='submit']"));
            Finish.Click();
            IWebElement avatar = driver.FindElement(By.ClassName("AvatarClient__avatar--3TC7_"));
            avatar.Click(); 
            IWebElement profile = driver.FindElement(By.ClassName("[class *=\"link link_type_navigation\"]")); 
            profile.Click();
            Assert.Fail();
        }

        [Test]
        public void RemovePhone()
        {
            IWebElement logIn = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logIn.Click();
            IWebElement logInEmail = driver.FindElement(By.CssSelector("[type='email']"));
            logInEmail.SendKeys("k.galchenko27@gmail.com");
            IWebElement logInPassword = driver.FindElement(By.CssSelector("[name='password']"));
            logInPassword.SendKeys("Nelegal95!");
            IWebElement Finish = driver.FindElement(By.CssSelector("[type='submit']"));
            Finish.Click();
            IWebElement avatar = driver.FindElement(By.ClassName("AvatarClient__avatar--3TC7_"));
            avatar.Click();
            IWebElement change = driver.FindElement(By.ClassName("[class *=\"edit-switcher__icon_type_edit\"]"));
            change.Click();
            IWebElement password = driver.FindElement(By.ClassName("[type *=\"password\"]"));
            password.SendKeys("Nelegal95!");
            IWebElement profile = driver.FindElement(By.ClassName("[class *=\"ng-pristine ng-valid input__self input__self_error input__self_type_text-underline ng-touched\"]"));
            profile.SendKeys("0987654321");
            IWebElement saveChanges = driver.FindElement(By.ClassName("[class *=\"button button_type_default\"]"));
            saveChanges.Click();
            Assert.Pass();
        }

        [Test]
        public void LogOut()
        {
            IWebElement logIn = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logIn.Click();
            IWebElement logInEmail = driver.FindElement(By.CssSelector("[type='email']"));
            logInEmail.SendKeys("k.galchenko27@gmail.com");
            IWebElement logInPassword = driver.FindElement(By.CssSelector("[name='password']"));
            logInPassword.SendKeys("Nelegal95!");
            IWebElement Finish = driver.FindElement(By.CssSelector("[type='submit']"));
            Finish.Click();
            IWebElement avatar = driver.FindElement(By.ClassName("AvatarClient__avatar--3TC7_"));
            avatar.Click();
            IWebElement editSwitcher = driver.FindElement(By.ClassName("edit-switcher__icon_type_edit"));
            editSwitcher.Click(); 
            IWebElement logOut = driver.FindElement(By.CssSelector("[class *=\"link link_type_logout link_active\"]"));
            logOut.Click();
            Assert.Pass();
        }

        [Test]
        public void AccountSettings()
        {
            IWebElement logIn = driver.FindElement(By.CssSelector("[class *=\"Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35\"]"));
            logIn.Click();
            IWebElement logInEmail = driver.FindElement(By.CssSelector("[type='email']"));
            logInEmail.SendKeys("k.galchenko27@gmail.com");
            IWebElement logInPassword = driver.FindElement(By.CssSelector("[name='password']"));
            logInPassword.SendKeys("Nelegal95!");
            IWebElement Finish = driver.FindElement(By.CssSelector("[type='submit']"));
            Finish.Click();
            IWebElement avatar = driver.FindElement(By.ClassName("AvatarClient__avatar--3TC7_"));
            avatar.Click();
            IWebElement editSwitcher = driver.FindElement(By.ClassName("edit-switcher__icon_type_edit"));
            editSwitcher.Click();
            IWebElement inputName = driver.FindElement(By.CssSelector("[type='text']"));
            inputName.SendKeys("_");
            IWebElement verifEmail = driver.FindElement(By.CssSelector("[class *=\"input__self_type_text-underline ng-untouched ng-pristine ng-valid\"]"));
            verifEmail.SendKeys("chenko");
            IWebElement location = driver.FindElement(By.CssSelector("[class *=\"input__self input__self_type_text-underline ng-untouched ng-pristine ng-valid pac-target-input\"]"));
            location.SendKeys("merica");
            Thread.Sleep(1500);
            location.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            location.SendKeys(Keys.Enter);
            IWebElement industry = driver.FindElement(By.CssSelector("[class *=\"input__self input__self_type_text-underline ng-pristine ng-valid ng-touched\"]"));
            industry.SendKeys("Cosmetics");
            IWebElement save = driver.FindElement(By.CssSelector("[type='submit']"));
            save.Click();
            IWebElement cardNumber = driver.FindElement(By.CssSelector("[name='company_website']"));
            cardNumber.SendKeys("5457082271328606");
            IWebElement expDate = driver.FindElement(By.CssSelector("[name='exp-date']"));
            expDate.SendKeys("0925");
            IWebElement cvc = driver.FindElement(By.CssSelector("[name='cvc']"));
            cvc.SendKeys("439");
            IWebElement saveCard = driver.FindElement(By.CssSelector("[type='submit']"));
            saveCard.Click();
            Assert.Pass();
        }

            [TearDown]
        public void After()
        {
            driver.Quit();
        }
    }
}