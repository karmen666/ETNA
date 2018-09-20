using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;


namespace WebAuthorityTests
{
    [TestFixture]


    public class UserCreateTests
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
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void UserCreateTest()
        {

           
            driver.Navigate().GoToUrl(baseURL + "dev/default.aspx?subj=doors/login");
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).SendKeys("katerina");
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).SendKeys("Lkaterina1234");
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_LoginButton")).Click();
            driver.FindElement(By.Id("SystemMainMenu")).Click();
            driver.FindElement(By.Id("UsersMainMenu")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("NewBtn")).Click();
            driver.FindElement(By.Id("Login")).Clear();
            driver.FindElement(By.Id("Login")).SendKeys("Tiger");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("666");
            driver.FindElement(By.Id("PasswordConfirm")).Clear();
            driver.FindElement(By.Id("PasswordConfirm")).SendKeys("666");
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys("White");
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("Tiger");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("white@tiger.com");
            driver.FindElement(By.Id("SubmitBtn")).Click();
            System.Threading.Thread.Sleep(1000);
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
