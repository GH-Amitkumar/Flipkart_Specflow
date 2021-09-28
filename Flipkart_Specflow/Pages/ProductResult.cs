using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Flipkart_Specflow.Pages
{
    public class ProductResult
    {
        private IWebDriver _driver;

        //[FindsBy(How = How.XPath, Using = "//button[@class='_2KpZ6l _2doB4z']")]
        //public IWebElement Cancel { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@class='_10Ermr' and contains(text(),'Showing 1 ')]")]
        public IWebElement pageLoadElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@Class='_1YokD2 _3Mn1Gg' and @Style='flex-grow: 1; overflow: auto;']//child::div[@Class='_1AtVbE col-12-12']")]
        public IList<IWebElement> lstDivElements { get; set; }


        public ProductResult(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool WaitPageToLoad()
        {
            Assert.IsTrue(pageLoadElement.Displayed);
            return true;
        }

        //public IWebDriver clickElement()
        //{
        //    Cancel.Click();
        //    return _driver;
        //}
        public void SearchTextAndClick(string searchText)
        {
            foreach (IWebElement ele in lstDivElements)
            {
                //if (ele.Text.Contains(searchText))
                //    ele.Click();

                string text = ele.Text.ToUpper().Trim();
                if (text.Contains(searchText.ToUpper().Trim()) && (!text.Contains("Currently unavailable")))
                {
                    ele.Click();
                    break;
                }
            }

            string popupHandle = string.Empty;
            string currTitle = _driver.Title;
            string BaseWindow = _driver.CurrentWindowHandle;
            ReadOnlyCollection<string> handles = _driver.WindowHandles;
            if (handles.Count > 1)
            {
                foreach (string handle in handles)
                {
                    if (handle != BaseWindow)
                    {
                        popupHandle = handle; 
                        break;
                    }
                }
                _driver.SwitchTo().Window(popupHandle);


            }
        }
    }
}
