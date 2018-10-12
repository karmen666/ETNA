using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAuthorityTests
{
    public class UserHelper
    {
        private IWebDriver driver;

        public UserHelper(IWebDriver driver)
        {
            this.driver = driver;
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


        public IWebElement WaitUntilElementIsFound(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id(name)));
            return myDynamicElement;
        }

        public void ShowAllUsers()
        {
            new SelectElement(driver.FindElement(By.Name("user_dgList_length"))).SelectByText("All");
        }

        public void RemoveLastUserInTheList()
        {
            driver.FindElement(By.Id("1180_deleteLink")).Click();
            WaitUntilElementIsFound(".btn.btn-danger").Click();
            // driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            IWebElement dialog = driver.FindElement(By.CssSelector(".modal-dialog"));
            dialog.FindElement(By.CssSelector(".btn.btn-default")).Click();
        }

    }
}
