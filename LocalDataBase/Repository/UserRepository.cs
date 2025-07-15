using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Classe de Repositórios de Dados de Usuários
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public async Task<List<User>> GetUserInUserIdList(List<int> userIds)
        {
            return await context.Users.Where(p => userIds.Contains(p.Id)).ToListAsync();
        }
    }
}
