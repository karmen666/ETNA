using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumTests
{
    [TestFixture]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
           
            driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            baseURL = "https://local.authoritycrm.com/";
        }



        [Test]
        public void TheUntitledTest()
        {
            driver.Navigate().GoToUrl(baseURL + "dev/default.aspx?subj=doors/login");
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).SendKeys("katerina");
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).SendKeys("Lkaterina1234");
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_LoginButton")).Click();
            driver.FindElement(By.Id("KaterinaLatyshevaMainMenu")).Click();
            driver.FindElement(By.Id("LogoutMainMenu")).Click();
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
            //    Assert.AreEqual("", verificationErrors.ToString());
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
