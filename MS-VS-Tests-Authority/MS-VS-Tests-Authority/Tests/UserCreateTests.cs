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
           
            UserDetails user = new UserDetails("Mem");
            user.Password = "12345";
            user.Passwordconfirm = "12345";
            user.Firstname = "Mem";
            user.Lastname = "Memych";
            user.Email = "memych@mem.com";

            app.User.Create(user);
           // app.User.WaitUntilElementIdFound("AndrewLuchkovMainMenu");
            app.Auth.InitLogOut();
        }
    }
}
