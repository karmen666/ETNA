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
    public class LoginLogOutHelper
    {
        private IWebDriver driver;

        public LoginLogOutHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public  void Login(LoginData account)
        {
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_UserName")).SendKeys(account.Username);
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).Clear();
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_Password")).SendKeys(account.Password);
            driver.FindElement(By.Id("ctl00_BodyPlaceholder_LoginLayoutLoader_ctl00_ContentLoader_ctl00_LoginButton")).Click();
        }
        public void InitLogOut()

        {
            driver.FindElement(By.Id("AndrewLuchkovMainMenu")).Click();
            driver.FindElement(By.Id("LogoutMainMenu")).Click();
        }
    }
}
