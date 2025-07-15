using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    
    public class UserRepository : BaseRepository<User>
    {
        public async Task<List<User>> GetUserInUserIdList(List<int> userIds)
        {
            return await context.Users.Where(p => userIds.Contains(p.Id)).ToListAsync();
        }
    }
}
