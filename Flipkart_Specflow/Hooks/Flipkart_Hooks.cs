using Flipkart_Specflow.Common;
using Flipkart_Specflow.BasePage;
using Flipkart_Specflow.Drivers;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Flipkart_Specflow.Hooks
{
    [Binding]
    public sealed class Flipkart_Hooks : BaseClass
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            if (DriverSetup.Browser == "Chrome")
            {
                driver = new ChromeDriver();
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            driver.Quit();
        }

        [AfterStep]
        public void AfterStep()
        {
            //TODO: implement logic that has to run after executing each scenario
            //driver.Quit();
            if (ScenarioContext.Current.TestError != null || ScenarioContext.Current.TestError == null)
            {
                CommonClass.TakeScreenshot(driver);
            }

        }
    }
}
