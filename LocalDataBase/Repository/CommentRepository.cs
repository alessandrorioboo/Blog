using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    
    public class CommentRepository : BaseRepository<Comment>
    {
        public async Task<List<Comment>> GetCommentsInPostIdList(List<int> postIds)
        {
            return await context.Comments.Where(p => postIds.Contains(p.PostId)).ToListAsync();
        }

    }
}
