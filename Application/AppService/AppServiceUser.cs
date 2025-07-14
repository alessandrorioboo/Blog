using ApplicationBlog.Helper;
using LocalDataBase.Model;
using System.Text.Json;

namespace ApplicationBlog.AppService
{
    public class AppServiceUser: AppServiceBase
    {
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
