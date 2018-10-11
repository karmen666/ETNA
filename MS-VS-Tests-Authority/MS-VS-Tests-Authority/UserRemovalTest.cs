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
            Login(new LoginData("admin", "gbd4fycr0t"));
            GoToUserList();
            ShowAllUsers();
            WaitUntilSpinnerVisible();
            RemoveLastUserInTheList();
            InitLogOut();
        }
    }
}
