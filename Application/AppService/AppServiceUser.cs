using ApplicationBlog.Helper;
using LocalDataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationBlog.AppService
{
    public class AppServiceUser: AppServiceBase
    {
        //JsonSerializerOptions _serializerOptions;

        //public AppServiceUser()
        //{
        //    _serializerOptions = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true,
        //        WriteIndented = true
        //    };
        //}

        public async Task<IList<User>> GetUsersByListIdAsync(IList<int> listId)
        {
            return await GetUsersByListId(listId);
        }

        private async Task<IList<User>> GetUsersByListId(IList<int> listId)
        {
            string jSonUsers = await APIBlogHelper.GetUserByListIdAsync(listId);
            IList<User>? users = null;

            if (!String.IsNullOrEmpty(jSonUsers))
            {
                users = JsonSerializer.Deserialize<IList<User>>(jSonUsers, _serializerOptions);
            }

            return users ?? new List<User>();
        }
    }
}
