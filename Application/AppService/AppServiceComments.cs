using ApplicationBlog.Helper;
using LocalDataBase.Model;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationBlog.AppService
{
    public class AppServiceComments: AppServiceBase
    {
        //JsonSerializerOptions _serializerOptions;

        //public AppServiceComments()
        //{
        //    _serializerOptions = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true,
        //        WriteIndented = true
        //    };
        //}

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
