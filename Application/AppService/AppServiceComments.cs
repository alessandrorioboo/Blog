using ApplicationBlog.Helper;
using LocalDataBase.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.AppService
{
    public class AppServiceComments
    {
        public async Task<IList<Comment>> GetCommentsByPostListIdAsync(IList<int> postListId)
        {
            return await GetCommentsByPostListId(postListId);
        }

        private async Task<IList<Comment>> GetCommentsByPostListId(IList<int> postListId)
        {
            string jSonUser = await APIBlogHelper.GetCommentsByPostListIdAsync(postListId);
            IList<Comment>? users = null;

            if (!String.IsNullOrEmpty(jSonUser))
            {
                users = JsonConvert.DeserializeObject<IList<Comment>>(jSonUser);
            }

            return users ?? new List<Comment>();
        }
    }
}
