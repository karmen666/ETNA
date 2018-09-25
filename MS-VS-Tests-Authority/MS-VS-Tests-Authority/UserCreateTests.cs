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
        public void UserCreationTest()
        {
            OpenLoginPage();
            Login(new LoginData("admin", "gbd4fycr0t"));
            GoToUserList();
            WaitUntilSpinnerVisible();
            InitNewUserCreation();
            UserDetails user = new UserDetails("Lemon");
            user.Password = "12345";
            user.Passwordconfirm = "12345";
            user.Firstname = "Limon";
            user.Lastname = "Limonych";
            user.Email = "limon@lime.com";
            FillNewUserForm(user);
            SubmitUserCreation();
            WaitUntilSpinnerVisible();
           // WaitUntilElementIsFound("AdministratorMainMenu");
            InitLogOut();
        }

        private void InitLogOut()
        {
            driver.FindElement(By.Id("AdministratorMainMenu")).Click();
            driver.FindElement(By.Id("LogoutMainMenu")).Click();
        }

        private void SubmitUserCreation()
        {
            driver.FindElement(By.Id("SubmitBtn")).Click();
        }

        private void FillNewUserForm(UserDetails user)
        {
            driver.FindElement(By.Id("Login")).Clear();
            driver.FindElement(By.Id("Login")).SendKeys(user.Login);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(user.Password);
            driver.FindElement(By.Id("PasswordConfirm")).Clear();
            driver.FindElement(By.Id("PasswordConfirm")).SendKeys(user.Passwordconfirm);
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys(user.Firstname);
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys(user.Lastname);
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(user.Email);
        }

        private void InitNewUserCreation()
        {
            driver.FindElement(By.Id("NewBtn")).Click();
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
            driver.Navigate().GoToUrl(baseURL + "dev/default.aspx?subj=doors/login");
        }

        public IWebElement WaitUntilElementIsFound(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id(name)));
            return myDynamicElement;
        }

        public void WaitUntilSpinnerVisible()
        {
            ICollection<IWebElement> Collection;
            do
            {
                Collection = driver.FindElements(By.ClassName("loader-wrapper"));
            } while (Collection.Count > 0);
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
