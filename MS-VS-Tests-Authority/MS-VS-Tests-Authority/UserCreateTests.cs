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
            navigator.OpenLoginPage();
            loginHelper.Login(new LoginData("Andrew", "Lass1979"));
            navigator.GoToUserList();
            userHelper.WaitUntilSpinnerVisible();
            userHelper.InitNewUserCreation();
            UserDetails user = new UserDetails("Anima");
            user.Password = "12345";
            user.Passwordconfirm = "12345";
            user.Firstname = "Limon";
            user.Lastname = "Limonych";
            user.Email = "limon@lime.com";
            userHelper.FillNewUserForm(user);
            userHelper.SubmitUserCreation();
            userHelper.WaitUntilSpinnerVisible();
            //WaitUntilElementIsFound("AdministratorMainMenu");
            loginHelper.InitLogOut();
        }
    }
}
