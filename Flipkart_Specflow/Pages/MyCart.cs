using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flipkart_Specflow.Pages
{
    public class MyCart
    {
        private IWebDriver _driver;

        [FindsBy(How =How.XPath, Using = "//*[contains(text(),'My Cart')]")]
        IWebElement eleMyCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Place Order')]//parent::button")]
        IWebElement eleBtnPlaceOrder { get; set; }

        public MyCart(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool WaitPageToLoad()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(eleMyCart.Displayed);
            return true;
        }

        public void eventElement(string actionName)
        {
            switch (actionName)
            {
                case "PLACE ORDER":
                    eleBtnPlaceOrder.Click();
                    break;
                    //default
            }
        }

    }
}
