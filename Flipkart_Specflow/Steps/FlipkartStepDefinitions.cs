using Flipkart_Specflow.Pages;
using Flipkart_Specflow.UtilityPage;
using TechTalk.SpecFlow;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Flipkart_Specflow.BasePage;

namespace Flipkart_Specflow.Steps
{
    [Binding]
    public sealed class FlipkartStepDefinitions:BaseClass
    {
        private readonly ScenarioContext _scenarioContext;
        //static IWebDriver driver = new ChromeDriver();
        //static IWebDriver driverr_;
        FlipkartHome objHomeFlipkart;
        // = new FlipkartHome(driver);
        UtilClass objUtil = new UtilClass();
        
        //-Interface call------
        //IHelperClass objHelper;

        //public FlipkartStepDefinitions(IHelperClass objIHelp) : base(objIHelp) { objHelper = objIHelp; }
        public FlipkartStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Launch Flipkart Website")]
        public void GivenLaunchFlipkartWebsite()
        {
            //testReport = extentReport.CreateTest("Test-1").Info("Method Started");

            objHomeFlipkart = new FlipkartHome(driver);

            objHomeFlipkart.launchUrl(driver);
        }

        [When(@"I click on ""(.*)"" button in ""(.*)"" page")]
        public void GivenIClickOnButtonInPage(string btnCancel, string pageName)
        {
            objUtil.ElementClick(pageName, btnCancel, driver);
        }

        [Then(@"I should be displayed with ""(.*)"" page")]
        public void ThenIShouldBeDisplayedWithPage(string pageName)
        {
            objUtil.PageToLoad(pageName, driver);
        }

        [When(@"I fill below details in ""(.*)"" page And I click on ""(.*)"" button")]
        public void WhenIFillBelowDetailsInPageAndIClickOnButton(string pageName, string btnSearch, Table table)
        {
            objUtil.PageInfoDetails(pageName, table, driver);
        }

        [When(@"I click on ""(.*)"" link in ""(.*)"" page")]
        public void WhenIClickOnLinkInPage(string productName, string pageName)
        {
            objUtil.SearchAndClick(pageName, productName, driver);
        }

        [Then(@"We should verify with ""(.*)"" text in ""(.*)"" page")]
        public void ThenWeShouldVerifyWithTextInPage(string productName, string pageName)
        {
            objUtil.Verify(pageName, productName, driver);
        }



    }

    public class CommonUtil
    {
        //internal IHelperClass objIHelp;
        public CommonUtil()
        {
            //objIHelp = obj;
        }
    }
}
