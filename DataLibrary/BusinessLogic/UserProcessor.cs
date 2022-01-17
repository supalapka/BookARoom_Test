using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static int Create(string login, string password)
        {

            UserModel user = new UserModel { Login = login, Password = password };

            string sql = @"insert into dbo.Users (Login, Password) 
                values (@Login, @Password);";

            return SqlDataAccess.SaveData(sql, user);
        }

        public static List<UserModel> Load()
        {
            string sql = @"select Id, Login, Password
            from dbo.Users;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }

    }
}
