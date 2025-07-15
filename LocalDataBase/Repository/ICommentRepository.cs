using LocalDataBase.Model;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Interface do Repositórios de Dados de Comentários
    /// </summary>
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<List<Comment>> GetCommentsInPostIdList(List<int> postIds);
    }
}