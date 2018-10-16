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
            app.Navigator.OpenLoginPage();
            app.Auth.Login(new LoginData("Andrew", "Lass1979"));
            app.Navigator.GoToUserList();
            app.User.ShowAllUsers();
            app.User.WaitUntilSpinnerVisible();
            app.User.RemoveLastUserInTheList();
            app.Auth.InitLogOut();
        }
    }
}
