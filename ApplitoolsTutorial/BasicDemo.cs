using Applitools.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;
using Applitools;

namespace ApplitoolsTutorial
{

    [TestFixture]
    public class BasicDemo
    {

        private IOSDriver driver;
        private Eyes eyes;
        [Test]
        public void IOSTest()
        {
            eyes = new Eyes();

            Configuration config = eyes.GetConfiguration();

            eyes.SetConfiguration(config);

            AppiumOptions options = new AppiumOptions();
            options.DeviceName = "iPhone 14 Pro Max";
            options.PlatformVersion = "16.2";
            options.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, "iOS");
            options.AutomationName = AutomationName.iOSXcuiTest;
            options.BrowserName = "Safari";

            driver = new IOSDriver(new Uri("http://127.0.0.1:4723"), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://lampsplus.com";


            eyes.Open(driver, "Lamps Plus", "Lamps Plus");

            eyes.Check("Lamps Plus", Target.Window().IgnoreDisplacements());

            eyes.Close();
            
        }

        [TearDown]
        public void AfterEach()
        {
            // Close the browser.
            driver.Quit();

            // If the test was aborted before eyes.close was called, ends the test as aborted.
            eyes.AbortIfNotClosed();
        }


        
    }
}
