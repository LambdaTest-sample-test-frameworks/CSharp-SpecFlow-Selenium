using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LambdaTestSpecFlow.steps
{

    [Binding]
    class Hooks
    {
        
        private static LambdaTestDriver ltDriver;
                
        [BeforeScenario]
        public static void Init()
        {
            ltDriver = new LambdaTestDriver(ScenarioContext.Current);
            ScenarioContext.Current["ltDriver"] = ltDriver;
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            ltDriver.getDriver().Quit();
            ltDriver = null;
        }

    }
}
