using System;
using System.Text;
using NUnit.Framework;


namespace WebAuthorityTests
{
    [TestFixture]
    public class UserRemovalTests : TestBase
    {
        
        [Test]
        public void UserRemovalTest()
        {
            navigator.OpenLoginPage();
            loginHelper.Login(new LoginData("Andrew", "Lass1979"));
            navigator.GoToUserList();
            userHelper.ShowAllUsers();
            userHelper.WaitUntilSpinnerVisible();
            userHelper.RemoveLastUserInTheList();
            loginHelper.InitLogOut();
        }
    }
}
