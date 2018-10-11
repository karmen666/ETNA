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
            OpenLoginPage();
            Login(new LoginData("Andrew", "Lass1979"));
            GoToUserList();
            ShowAllUsers();
            WaitUntilSpinnerVisible();
            RemoveLastUserInTheList();
            InitLogOut();
        }
    }
}
