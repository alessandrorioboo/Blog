using ApplicationBlog.Helper;
using LocalDataBase.Model;
using System.Text.Json;

namespace ApplicationBlog.AppService
{
    public class AppServiceComments: AppServiceBase
    {        
        public async Task<List<Comment>> GetCommentsByPostListIdAsync(List<int> postListId)
        {
            return await GetCommentsByPostListId(postListId);
        }

        private async Task<List<Comment>> GetCommentsByPostListId(List<int> postListId)
        {
            string jSonComments = await APIBlogHelper.GetCommentsByPostListIdAsync(postListId);
            List<Comment>? comments = null;

            if (!String.IsNullOrEmpty(jSonComments))
            {
                comments = JsonSerializer.Deserialize<List<Comment>>(jSonComments, _serializerOptions);
            }

            return comments ?? new List<Comment>();
        }
    }
}
