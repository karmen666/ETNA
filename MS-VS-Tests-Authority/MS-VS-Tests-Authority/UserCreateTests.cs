using System;
using System.Text;
using NUnit.Framework;



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
            UserDetails user = new UserDetails("Alima");
            user.Password = "12345";
            user.Passwordconfirm = "12345";
            user.Firstname = "Limon";
            user.Lastname = "Limonych";
            user.Email = "limon@lime.com";
            FillNewUserForm(user);
            SubmitUserCreation();
            WaitUntilSpinnerVisible();
            //WaitUntilElementIsFound("AdministratorMainMenu");
            InitLogOut();
        }

       

    }
}
