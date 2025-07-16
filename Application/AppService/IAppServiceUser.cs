using LocalDataBase.Model;

namespace Application.AppService
{
    /// <summary>
    /// Interface de Serviços de Usuários
    /// </summary>
    public interface IAppServiceUser
    {
        Task<List<User>> GetUserInUserIdList(List<int> userIds);
        Task<List<User>> GetUsersByListIdAsync(List<int> listId);
        Task RemoveAll();
    }
}