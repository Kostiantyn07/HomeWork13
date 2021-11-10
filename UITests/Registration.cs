using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.POM
{
    class RegistrationPages
    {
        private readonly IWebDriver _webDriver;

        private readonly By _buttonSignUp = By.CssSelector("[class='Navbar__signUp--12ZDV']");
        private readonly By _firstName = By.CssSelector("[name = 'first_name']");
        private readonly By _lastName = By.CssSelector("[name = 'last_name']");
        private readonly By _emailUser = By.CssSelector("[name='email']");
        private readonly By _paswordUser = By.CssSelector("[name='password']");
        private readonly By _confirmPaswordUser = By.CssSelector("[name='password_confirm']");
        private readonly By _phoneUser = By.CssSelector("[name='phone_number']");
        private readonly By _buttonNext = By.CssSelector("[type='submit']");
        private readonly By _companyName = By.CssSelector("[name='company_name']");


        public RegistrationPages(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public RegistrationPages GoToRegistrationPages()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/");
            _webDriver.FindElement(_buttonSignUp).Click();
            return this;
        }

        public RegistrationPages InputFirstName(string firstName)
        {
            _webDriver.FindElement(_firstName).SendKeys(firstName);
            return this;
        }

        public RegistrationPages InputLastName(string lastName)
        {
            _webDriver.FindElement(_lastName).SendKeys(lastName);
            return this;
        }

        public RegistrationPages InputEmail(string mail)
        {
            _webDriver.FindElement(_emailUser).SendKeys(mail);
            return this;
        }

        public RegistrationPages InputPassword(string paswd)
        {
            _webDriver.FindElement(_paswordUser).SendKeys(paswd);
            return this;
        }

        public RegistrationPages InputConfirmPassword(string paswd)
        {
            _webDriver.FindElement(_confirmPaswordUser).SendKeys(paswd);
            return this;
        }

        public RegistrationPages InputPhoneNumber(string number)
        {
            _webDriver.FindElement(_phoneUser).SendKeys(number);
            return this;
        }

        public void ClickNextButton()
        {
            _webDriver.FindElement(_buttonNext).Click();
        }

        public RegistrationPages InputCompanyName(string number)
        {
            _webDriver.FindElement(_companyName).SendKeys(number);
            return this;
        }

       

       
    }
}
