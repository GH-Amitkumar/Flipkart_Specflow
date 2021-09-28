using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Flipkart_Specflow.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flipkart_Specflow.BasePage
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public static ExtentReports extentReport = null;
        public static ExtentTest testReport = null;
        public BaseClass()
        {
            //if (DriverSetup.Browser == "Chrome")
            //{
            //    driver = new ChromeDriver();
            //}
            //string data = string.Empty;
        }

        /*
        [OneTimeSetUp]
        public void Open()
        {
            //driver = new ChromeDriver();
            //driver.Url = "https://www.youtube.com/";

            //extentReport = new ExtentReports();
            //var htmlReporter = new ExtentHtmlReporter(DriverSetup.ReportPath + @"Extent_Report.html");
            ////var htmlReporter = new ExtentHtmlReporter(ReportPath + @"Extent_Report.html", false, DisplayOrder.NewestFirst);
            //extentReport.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        //[TearDown]
        public void Close()
        {
            driver.Quit();
            //extentReport.Flush();
        }
        */
    }
}
