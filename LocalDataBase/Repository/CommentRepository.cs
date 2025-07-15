using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Classe de Repositórios de Dados de Comentários
    /// </summary>
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public async Task<List<Comment>> GetCommentsInPostIdList(List<int> postIds)
        {
            return await context.Comments.Where(p => postIds.Contains(p.PostId)).ToListAsync();
        }

    }
}
