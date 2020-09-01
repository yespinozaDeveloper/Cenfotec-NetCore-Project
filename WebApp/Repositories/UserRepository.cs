using Models.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class UserRepository
    {
        private const string LOGIN_FORMAT = "User/{0}/{1}";

        public static async Task<UserEntity> Login(string user, string password)
        {
            var userObj = await NetworkHelper.getInstance().Get<UserEntity>(string.Format(LOGIN_FORMAT,user,password));
            ApplicationCacheData.getInstance().CurrentUser = userObj;
            return userObj;
        }
    }
}
