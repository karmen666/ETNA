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
    public class NavigationHelper:HelperBase
    {
        private string baseURL;


        public NavigationHelper(IWebDriver driver, string baseURL): base (driver)
        {
            this.baseURL = baseURL;
        }
        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "test/default.aspx?subj=doors/login&returnUrl=%2ftest%2f");
        }

        public void GoToUserList()
        {
            driver.FindElement(By.Id("SystemMainMenu")).Click();
            driver.FindElement(By.Id("UsersMainMenu")).Click();
        }


    }
}
