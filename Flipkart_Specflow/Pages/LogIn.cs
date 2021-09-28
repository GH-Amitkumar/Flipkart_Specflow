//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using OpenQA.Selenium.Remote;
//using NUnit.Framework;
//using System.Threading;
//using System.Linq;
//using System.Threading.Tasks;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.PageObjects;
//using FindsByAttribute = OpenQA.Selenium.Support.PageObjects.FindsByAttribute;
//using How = OpenQA.Selenium.Support.PageObjects.How;

using System;
using System.Collections.Generic;
using System.Text;
using Flipkart_Specflow.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace Flipkart_Specflow.Pages
{
    public class LogIn
    {
        private IWebDriver _driver;

        //[FindsBy(How = How.XPath, Using = "//button[@class='_2KpZ6l _2doB4z']")]
        //public IWebElement Cancel { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@class='_2KpZ6l _2doB4z']")]
        public IWebElement Cancel { get; set; }

        public LogIn(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void eventElement(string actionName)
        {
            switch(actionName)
            {
                case "cancel":
                    Cancel.Click();
                    break;
                //default
            }          
        }

    }
}
