using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13

{
    class SignInUser
    {
        private readonly IWebDriver _webDriver;

        private readonly By _emailField = By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']");
        private readonly By _passwordField = By.CssSelector("input[type=\"password\"]");
        private readonly By _buttonLogIn = By.CssSelector("button[class^='SignInForm__submitButton--cUdOV']");
        private readonly By _errorMessage = By.CssSelector("[class ='PageFormLayout__errors--3dFcq']>[class]");
        private readonly By _errorMessageByEmail = By.XPath("//input[@name = 'email']/../div[@class='FormErrorText__error---nzyq']");
        private readonly By _errorMessageByPass = By.XPath("//input[@name = 'password']/../div[@class='FormErrorText__error---nzyq']/div");

        public SignInUser(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInUser GoSignInUser()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInUser MailField(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignInUser PasswordField(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

    }
}
