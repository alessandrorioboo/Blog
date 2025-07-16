using LocalDataBase.Model;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Interface do Repositórios de Dados de Postagens
    /// </summary>
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task AddOrUpdateAllAlternativo(List<Post> listPost);
    }
}