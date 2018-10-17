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
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginLogOutHelper loginHelper;
        protected NavigationHelper navigator;
        protected UserHelper userHelper;

        public ApplicationManager()
        {
            driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            baseURL = "https://demo.authoritycrm.com/";
            driver.Manage().Window.Maximize();

            loginHelper = new LoginLogOutHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            userHelper = new UserHelper(this);
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }


        public void Stop()
        {

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginLogOutHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public UserHelper User
        {
            get
            {
                return userHelper;
            }
        }

    }
}
