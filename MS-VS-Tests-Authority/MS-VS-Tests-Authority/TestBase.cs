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

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            baseURL = "https://demo.authoritycrm.com/";
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
          //   Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "test/default.aspx?subj=doors/login&returnUrl=%2ftest%2f");
        }

        protected void Login(LoginData account)
        {
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).SendKeys(account.Username);
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).SendKeys(account.Password);
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_LoginButton")).Click();
        }
        public void InitLogOut()
        {
            driver.FindElement(By.Id("AdministratorMainMenu")).Click();
            driver.FindElement(By.Id("LogoutMainMenu")).Click();
        }

        public void SubmitUserCreation()
        {
            driver.FindElement(By.Id("SubmitBtn")).Click();
        }

        public void WaitUntilSpinnerVisible()
        {
            ICollection<IWebElement> Collection;
            do
            {
                Collection = driver.FindElements(By.ClassName("loader-wrapper"));
            } while (Collection.Count > 0);
        }

      public void FillNewUserForm(UserDetails user)
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

        public void InitNewUserCreation()
        {
            driver.FindElement(By.Id("NewBtn")).Click();
        }

        public void GoToUserList()
        {
            driver.FindElement(By.Id("SystemMainMenu")).Click();
            driver.FindElement(By.Id("UsersMainMenu")).Click();
        }

        public IWebElement WaitUntilElementIsFound(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id(name)));
            return myDynamicElement;
        }
        
        public void ShowAllUsers()
        {
            new SelectElement(driver.FindElement(By.Name("user_dgList_length"))).SelectByText("All");
        }

        public void RemoveLastUserInTheList()
        {
            driver.FindElement(By.Id("1167_deleteLink")).Click();
            DriverAlert();
        }
        public void DriverAlert()
        {
            driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
        }
    }
}
