using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyOnlineBanker.Models
{
    [Table("LoginUser")]
    public class LoginUser
    {
        
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string LoginDate { get; set; }

        public LoginUser(string username)
        {
            Username = username;
            LoginDate = DateTime.Now.ToString();
        }

        public LoginUser()
        {
            
        }
    }
}
