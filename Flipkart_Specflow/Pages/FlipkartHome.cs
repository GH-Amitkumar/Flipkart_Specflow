using AventStack.ExtentReports;
using Flipkart_Specflow.BasePage;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;



namespace Flipkart_Specflow.Pages
{
    public class FlipkartHome //: BaseClass
    {
        private IWebDriver _driver;

        FlipkartProductData objProductData = new FlipkartProductData();

        [FindsBy(How = How.XPath, Using = "//img[@class='_2xm1JU']")]
        public IWebElement pageLoadElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='_3704LK']")]
        public IWebElement SearchTextboxElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='L0Z3Pu']")]
        public IWebElement SearchClickElement { get; set; }

        public FlipkartHome(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void launchUrl(IWebDriver driver)
        {
            
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            //return driver;
            //BaseClass.testReport.Log(Status.Pass, "URL is Launched");
        }

        public bool WaitPageToLoad()
        {
            Assert.IsTrue(pageLoadElement.Displayed);
            return true;
        }

        public void PopulateData(Table table)
        {
            
            FlipkartProductData locationRequest = table.CreateInstance<FlipkartProductData>();
            SearchTextboxElement.SendKeys(locationRequest.SearchProduct);
            SearchClickElement.Click();

            //IJavaScriptExecutor jsSetInput = (IJavaScriptExecutor) driver;
            ////jsSetInput.ExecuteScript("document.getElementByClassName('_3704LK').value='"+ locationRequest.SearchProduct + "'");
            //jsSetInput.ExecuteScript("arguments[0].value='_3704LK'", locationRequest.SearchProduct);

            //List<FlipkartProductData> locationRequest = table.CreateSet<FlipkartProductData>();


        }
    }

    public class FlipkartProductData
    {
        public string SearchProduct { get; set; }
        public string ProductItem { get; set; }

    }
}
