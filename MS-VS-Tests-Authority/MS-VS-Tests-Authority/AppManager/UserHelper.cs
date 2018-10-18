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
    public class UserHelper: HelperBase
    {

        public UserHelper(ApplicationManager manager): base (manager)
        {
        }

        public UserHelper Create(UserDetails user)
        {
            manager.Navigator.GoToUserList();
            WaitUntilSpinnerVisible();
            InitNewUserCreation();
            FillNewUserForm(user);
            SubmitUserCreation();
            WaitUntilSpinnerVisible();
            return this;
        }

        public UserHelper Remove(UserDetails user)
        {
            
            return this;
        }

        public UserHelper SubmitUserCreation()
        {
            driver.FindElement(By.Id("SubmitBtn")).Click();
            return this;
        }

        public void WaitUntilSpinnerVisible()
        {
            ICollection<IWebElement> Collection;
            do
            {
                Collection = driver.FindElements(By.ClassName("loader-wrapper"));
            } while (Collection.Count > 0);
        }

        public IWebElement WaitUntilElementIsFound(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(name)));
            return myDynamicElement;
        }

        public IWebElement WaitUntilElementIdFound(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id(name)));
            return myDynamicElement;
        }

        public UserHelper FillNewUserForm(UserDetails user)
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
            return this;
        }

        public UserHelper InitNewUserCreation()
        {
            driver.FindElement(By.Id("NewBtn")).Click();
            return this;
        }

        public UserHelper ShowAllUsers()
        {
            new SelectElement(driver.FindElement(By.Name("user_dgList_length"))).SelectByText("All");
            return this;
        }

        public UserHelper RemoveLastUserInTheList()
        {
            driver.FindElement(By.Id("1198_deleteLink")).Click();
            WaitUntilElementIsFound(".btn.btn-danger");
            driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            WaitUntilElementIsFound(".alert.alert-danger");
            IWebElement dialog = driver.FindElement(By.CssSelector(".modal-dialog"));
            dialog.FindElement(By.CssSelector(".btn.btn-default")).Click();
            return this;
        }
    }
}
