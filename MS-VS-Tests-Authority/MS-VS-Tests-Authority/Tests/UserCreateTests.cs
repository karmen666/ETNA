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
            app.Navigator.OpenLoginPage();
            app.Auth.Login(new LoginData("Andrew", "Lass1979"));
            app.Navigator.GoToUserList();
            app.User.WaitUntilSpinnerVisible();
            app.User.InitNewUserCreation();
            UserDetails user = new UserDetails("Anima");
            user.Password = "12345";
            user.Passwordconfirm = "12345";
            user.Firstname = "Limon";
            user.Lastname = "Limonych";
            user.Email = "limon@lime.com";
            app.User.FillNewUserForm(user);
            app.User.SubmitUserCreation();
            app.User.WaitUntilSpinnerVisible();
            //WaitUntilElementIsFound("AdministratorMainMenu");
            app.Auth.InitLogOut();
        }
    }
}
