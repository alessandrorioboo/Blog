using ApplicationBlog.Helper;
using LocalDataBase.Model;
using LocalDataBase.Repository;
using System.Text.Json;

namespace ApplicationBlog.AppService
{
    public class AppServiceUser: AppServiceBase
    {
        private UserRepository _userRepository = new UserRepository();

        public async Task<List<User>> GetUserInUserIdList(List<int> userIds)
        {
            return await _userRepository.GetUserInUserIdList(userIds);
        }


        public async Task RemoveAll()
        {
            await _userRepository.RemoveAll();
        }

        public async Task<List<User>> GetUsersByListIdAsync(List<int> listId)
        {
            return await GetUsersByListId(listId);
        }

        private async Task<List<User>> GetUsersByListId(List<int> listId)
        {
            string jSonUsers = await APIBlogHelper.GetUserByListIdAsync(listId);
            List<User>? users = null;

            if (!String.IsNullOrEmpty(jSonUsers))
            {
                users = JsonSerializer.Deserialize<List<User>>(jSonUsers, _serializerOptions);
            }

            return users ?? new List<User>();
        }
    }
}
