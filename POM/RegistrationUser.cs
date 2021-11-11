using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork13
{
    class RegistrationUser
    {
        private readonly IWebDriver _webDriver;

        private readonly By _buttonSignUp = By.CssSelector("[class='Navbar__signUp--12ZDV']");
        private readonly By _firstName = By.CssSelector("[name = 'first_name']");
        private readonly By _lastName = By.CssSelector("[name = 'last_name']");
        private readonly By _emailUser = By.CssSelector("[name='email']");
     
    }
}
