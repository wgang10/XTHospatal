using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wintrue
{
    public class Account
    {
        public Account(string loginID, string loginPWD, string userID, string nickName, string email, string phone)
        {
            LoginID = loginID;
            LoginPWD = loginPWD;
            UserID = userID;
            NickName = nickName;
            Email = email;
            Phone = phone;
        }
        public string LoginID
        {
            set;
            get;
        }

        public string LoginPWD { get; set; }

        public string UserID { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
