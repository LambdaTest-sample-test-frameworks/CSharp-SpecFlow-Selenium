using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LambdaTestSpecFlow.steps
{
    public class LambdaTestDriver
    {
        private IWebDriver driver;
        private String ltUserName;
        private String ltAppKey;
        private String plateform;
        private String browser;
        private String browserVersion;
        private String LambdaTestUser;
        private String LambdaTestKey;
           
        private ScenarioContext context;

        public LambdaTestDriver(ScenarioContext context)
        {
            this.context = context;
        }

        public IWebDriver Init()
        {
            this.InitCaps();
            DesiredCapabilities caps1 = new DesiredCapabilities();
            caps1.SetCapability("platform", plateform);
            caps1.SetCapability("browserName", browser);
            caps1.SetCapability("version", browserVersion);
            caps1.SetCapability("user", ltUserName);
            caps1.SetCapability("accessKey", ltAppKey);
            caps1.SetCapability("build", "LambdaTestSampleApp");
            caps1.SetCapability("name", "LambdaTestSpecFlowSample");
            caps1.SetCapability("network", true); // To enable network logs
            caps1.SetCapability("visual", true); // To enable step by step screenshot
            caps1.SetCapability("video", true); // To enable video recording
            caps1.SetCapability("console", true); // To capture console logs
            driver = new RemoteWebDriver(new Uri(ConfigurationSettings.AppSettings["LTUrl"]), caps1, TimeSpan.FromSeconds(600));
            return driver;
        }

        public IWebDriver getDriver()
        {
            return driver;          
        }

        public void InitCaps()
        {
            if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable("LT_USERNAME")))
            {
                this.ltUserName = ConfigurationSettings.AppSettings["LTUser"];
            }

            if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable("LT_APPKEY")))
                this.ltAppKey = ConfigurationSettings.AppSettings["LTAccessKey"];

            if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable("LT_OPERATING_SYSTEM")))
                this.plateform = ConfigurationSettings.AppSettings["OS"];

            if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable("LT_BROWSER")))
                this.browser = ConfigurationSettings.AppSettings["Browser"];

            if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable("LT_BROWSER_VERSION")))
                this.browserVersion = ConfigurationSettings.AppSettings["BrowserVersion"];
        }
    }
}
