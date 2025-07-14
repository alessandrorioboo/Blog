using ApplicationBlog.Helper;
using LocalDataBase.Model;
using System.Text.Json;

namespace ApplicationBlog.AppService
{
    public class AppServiceComments: AppServiceBase
    {        
        public async Task<IList<Comment>> GetCommentsByPostListIdAsync(IList<int> postListId)
        {
            return await GetCommentsByPostListId(postListId);
        }

        private async Task<IList<Comment>> GetCommentsByPostListId(IList<int> postListId)
        {
            string jSonComments = await APIBlogHelper.GetCommentsByPostListIdAsync(postListId);
            IList<Comment>? comments = null;

            if (!String.IsNullOrEmpty(jSonComments))
            {
                comments = JsonSerializer.Deserialize<IList<Comment>>(jSonComments, _serializerOptions);
            }

            return comments ?? new List<Comment>();
        }
    }
}
