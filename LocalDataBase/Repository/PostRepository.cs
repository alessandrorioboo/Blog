using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    
    public class PostRepository : BaseRepository<Post>
    {
        //public override async Task<List<Post>> GetAll()
        //{
        //    context.Posts.Include(x => x.Comments);
        //    return await context.Posts.ToListAsync();
        //}

        //GetAllPostsPaged(items, page);
    }
}
