using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static async Task CreateAsync(string login, string password)
        {

            UserModel user = new UserModel { Login = login, Password = password };

            string sql = @"insert into dbo.Users (Login, Password) 
                values (@Login, @Password);";

            await SqlDataAccess.SaveDataAsync(sql, user);
        }

        public static async Task<List<UserModel>> LoadAsync()
        {
            string sql = @"select Id, Login, Password
            from dbo.Users;";

            return await SqlDataAccess.LoadDataAsync<UserModel>(sql);
        }

    }
}
