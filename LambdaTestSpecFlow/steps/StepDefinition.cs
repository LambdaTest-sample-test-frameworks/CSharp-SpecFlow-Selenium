using LambdaTestSpecFlow.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LambdaTestSpecFlow.steps
{
   
    [Binding]
    public sealed class StepDefinition
    {
        private IWebDriver driver;
        private string AppUrl;
        private AdvancePage advancePage;
        private String testData = "Yey, Let's add it to list";

        private IWebDriver _driver;
        readonly LambdaTestDriver ltDriver;

        public StepDefinition()
        {
            ltDriver = (LambdaTestDriver)ScenarioContext.Current["ltDriver"];
        }

        [Given(@"I am on home page")]
        public void GivenIAmOnHomePage()
        {
            AppUrl = ConfigurationSettings.AppSettings["URL"];
            driver = ltDriver.Init();
            driver.Navigate().GoToUrl(AppUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            advancePage = new AdvancePage(driver);
        }

        [When(@"I click on First Check Box")]
        public void GivenIClickOnFirstCheckBox()
        {
            advancePage.ClickFirstCheckBox();
        }

        [When(@"I Click on Second Check Box")]
        public void GivenIClickOnSecondCheckBox()
        {
            advancePage.ClickSecondCheckBox();
        }

        [When(@"I enter Item Name")]
        public void GivenIEnterItemName()
        {
            advancePage.EnterItemName(testData);
        }

        [When(@"I click on Add Button")]
        public void GivenIClickOnAddButton()
        {
            advancePage.ClickOnAddButton();
        }

        [Then(@"I can verify Added item")]
        public void ThenICanVerifyAddedItem()
        {
            advancePage.verifiedAddedItem(testData);
        }

    }
}
