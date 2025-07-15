using LocalDataBase.Model;

namespace ApplicationBlog.AppService
{
    /// <summary>
    /// Interface de Serviços de Comentários
    /// </summary>
    public interface IAppServiceComment
    {
        Task<List<Comment>> GetCommentsByPostListIdAsync(List<int> postListId);
        Task<List<Comment>> GetCommentsInPostIdList(List<int> postIds);
        Task RemoveAll();
    }
}