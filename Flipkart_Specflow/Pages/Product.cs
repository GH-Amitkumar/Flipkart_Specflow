using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flipkart_Specflow.Pages
{
    public class Product
    {
        private IWebDriver _driver; 

        [FindsBy(How = How.ClassName, Using = "B_NuCI")]
        IWebElement ProductElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@Class='_2KpZ6l _2U9uOA _3v1-ww']")]
        IWebElement eleAddToCart { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@Class='aMaAEs']")]
        //IList<IWebElement> eleListDiv { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[@Class='_2KpZ6l _2U9uOA _3v1-ww']")]
        IWebElement eleBtnAddToCart { get; set; }

        public Product(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool WaitPageToLoad()
        {
            Assert.IsTrue(ProductElement.Displayed);         
            return true;
        }

        public bool Validate(string searchText)
        {
            bool flag = false;
            string eleText = ProductElement.Text.ToUpper().Trim();
            //Assert.Contains(searchText.ToUpper().Trim(), eleText);
            flag = eleText.Contains(searchText);
            return flag;
            
        }

        //public void AddToCart()
        //{
        //    eleBtnAddToCart.Click();
        //}

        public void eventElement(string actionName)
        {
            switch (actionName)
            {
                case "Add To Cart":
                    eleBtnAddToCart.Click();
                    break;
                    //default
            }
        }
    }
}
