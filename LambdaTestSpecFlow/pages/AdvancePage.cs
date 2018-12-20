using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LambdaTestSpecFlow.Pages
{
    class AdvancePage
    {
        private IWebDriver driver;

        public AdvancePage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Name, Using = "li1")]
        public IWebElement firstCheckBox { get; set; }

        [FindsBy(How = How.Name, Using = "li2")]
        public IWebElement secondCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "sampletodotext")]
        public IWebElement itemInputField { get; set; }

        [FindsBy(How = How.Id, Using = "addbutton")]
        public IWebElement addButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/ul/li[6]/span")]
        public IWebElement textLink { get; set; }


        public void ClickFirstCheckBox()
        {
            firstCheckBox.Click();
        }

        public void ClickSecondCheckBox()
        {
            secondCheckBox.Click();
        }

        public void EnterItemName(string itemName)
        {
            itemInputField.SendKeys(itemName);
        }

        public void ClickOnAddButton()
        {
            addButton.Click();
        }

        public void verifiedAddedItem(string text)
        {          
            Assert.AreEqual(textLink.Text, text, "Does not get added Item name !!!");          
        }
    }
}
