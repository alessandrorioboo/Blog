using LocalDataBase.Model;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Ingterface Base de Repositórios de Modelos de Dados
    /// </summary>
    /// <typeparam name="T">O Tipo do Modelo de Dados</typeparam>
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task Add(T model);
        Task AddAll(IList<T> listModel);
        Task AddOrUpdate(T model);
        Task AddOrUpdateAll(List<T> listModel);
        Task<List<T>> GetAll();
        Task<List<T>> GetAllPostsPaged(int items, int page);
        Task<int> GetQttRows();
        Task RemoveAll();
    }
}