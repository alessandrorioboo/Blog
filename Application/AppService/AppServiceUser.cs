using ApplicationBlog.Helper;
using LocalDataBase.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.AppService
{
    public class AppServiceUser
    {
        public async Task<IList<User>> GetUsersByListIdAsync(IList<int> listId)
        {
            return await GetUsersByListId(listId);
        }

        private async Task<IList<User>> GetUsersByListId(IList<int> listId)
        {
            string jSonUser = await APIBlogHelper.GetUserByListIdAsync(listId);
            IList<User>? users = null;

            if (!String.IsNullOrEmpty(jSonUser))
            {
                users = JsonConvert.DeserializeObject<IList<User>>(jSonUser);
            }

            return users ?? new List<User>();
        }
    }
}
