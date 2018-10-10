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

    public class UserCreateTests :TestBase
    {
               
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
    }
}
