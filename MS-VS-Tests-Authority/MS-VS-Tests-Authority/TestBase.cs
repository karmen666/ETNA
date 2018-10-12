using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebAuthorityTests
{
    public class TestBase
    {
        protected IWebDriver driver;
     //   private StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginLogOutHelper loginHelper;
        protected NavigationHelper navigator;
        protected UserHelper userHelper;


        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            baseURL = "https://demo.authoritycrm.com/";
            driver.Manage().Window.Maximize();

            loginHelper = new LoginLogOutHelper(driver);
            navigator = new NavigationHelper(driver,baseURL);
            userHelper = new UserHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
          //   Assert.AreEqual("", verificationErrors.ToString());
        }

      
        
    }
}
