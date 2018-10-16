using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAuthorityTests
{
   public class UserDetails
    {

        private string login;
        private string password;
        private string passwordconfirm;
        private string firstname;
        private string lastname;
        private string email;

        public UserDetails(string login, string password, string passwordconfirm, string firstname, string lastname, string email)
        {
            this.login = login;
            this.password = password;
            this.passwordconfirm = passwordconfirm;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
        }

        public UserDetails(string login)
        {
            this.login = login;
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string Passwordconfirm
        {
            get
            {
                return passwordconfirm;
            }
            set
            {
                passwordconfirm = value;
            }
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
    }
}
