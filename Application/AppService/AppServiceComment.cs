using ApplicationBlog.Helper;
using LocalDataBase.Model;
using LocalDataBase.Repository;
using System.Text.Json;

namespace ApplicationBlog.AppService
{
    public class AppServiceComment: AppServiceBase
    {
        private CommentRepository _commentRepository = new CommentRepository();

        public async Task RemoveAll()
        {
            await _commentRepository.RemoveAll();
        }

        public async Task<List<Comment>> GetCommentsInPostIdList(List<int> postIds)
        {
            return await _commentRepository.GetCommentsInPostIdList(postIds);
        }
        
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
