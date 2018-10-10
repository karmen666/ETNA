using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace WebAuthorityTests
{
    [TestFixture]
    public class UserRemovalTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            baseURL = "https://demo.authoritycrm.com/";
            verificationErrors = new StringBuilder();
            driver.Manage().Window.Maximize();

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
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void UserRemovalTest()
        {
            OpenLoginPage();
            Login(new LoginData("admin", "gbd4fycr0t"));
            GoToUserList();
            ShowAllUsers();
            WaitUntilSpinnerVisible();
            RemoveLastUserInTheList();
        }

        private void ShowAllUsers()
        {
            new SelectElement(driver.FindElement(By.Name("user_dgList_length"))).SelectByText("All");
        }

        private void RemoveLastUserInTheList()
        {
            
            driver.FindElement(By.Id("1122_deleteLink")).Click();
            DriverAlert();
        }

        

        private void GoToUserList()
        {
            driver.FindElement(By.Id("SystemMainMenu")).Click();
            driver.FindElement(By.Id("UsersMainMenu")).Click();
        }

        private void Login(LoginData account)
        {
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).SendKeys(account.Username);
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).SendKeys(account.Password);
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_LoginButton")).Click();
        }

        private void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "test/default.aspx?subj=doors/login&returnUrl=%2ftest%2f");
        }

        public void WaitUntilSpinnerVisible()
        {
            ICollection<IWebElement> Collection;
            do
            {
                Collection = driver.FindElements(By.ClassName("loader-wrapper"));
            } while (Collection.Count > 0);
        }


        public void DriverAlert()
        {
           // driver.FindElement(By.ClassName("btn btn_danger")).Click();
            driver.FindElement(By.XPath("//button[@class='btn btn_danger']")).Click();

        
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
