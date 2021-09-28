using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flipkart_Specflow.Pages
{
    public class LoginorSignup
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//*[text()='Login or Signup']//parent::h3")]
        IWebElement eleLoginorSignup { get; set; }

        public LoginorSignup(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool WaitPageToLoad()
        {
            Assert.IsTrue(eleLoginorSignup.Displayed);
            return true;
        }
    }
}
