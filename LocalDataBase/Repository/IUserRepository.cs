using LocalDataBase.Model;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Interface do Repositórios de Dados de Usuários
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetUserInUserIdList(List<int> userIds);
    }
}