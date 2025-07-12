using ApplicationBlog.Helper;
using LocalDataBase.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModel;

namespace ApplicationBlog.AppService
{
    public class AppServicePost
    {
        public async Task<IList<PostViewModel>> GetPostsAsyncViewModel(int itens, int page, bool online)
        {
            var posts = await GetPostsAsync(itens, page, online);

            var jSonPosts = JsonConvert.SerializeObject(posts);
            var postsViewModel = JsonConvert.DeserializeObject<IList<PostViewModel>>(jSonPosts);

            return postsViewModel ?? new List<PostViewModel>();
        }

        public async Task<IList<Post>> GetPostsAsync(int itens, int page, bool online)
        {
            var posts = await GetAllPosts();
            posts = posts.OrderByDescending(p => p.Id).Skip((page - 1) * itens).Take(itens).ToList();

            if (posts != null && posts.Count > 0)
            {
                var userIdList = posts.Select(p => p.UserId).Distinct().ToList();
                AppServiceUser appServiceUser = new AppServiceUser();
                var usersTask = appServiceUser.GetUsersByListIdAsync(userIdList);

                var postIdList = posts.Select(p => p.Id).Distinct().ToList();
                AppServiceComments appServiceComments = new AppServiceComments();
                var commentsTask = appServiceComments.GetCommentsByPostListIdAsync(postIdList);

                var users = await usersTask;
                var comments = await commentsTask;

                posts = (from post in posts
                         join user in users
                         on post.UserId equals user.Id
                         select new Post(post, user, comments.Where(comment => comment.PostId == post.Id).ToList())).OrderByDescending(p => p.Id).ToList();
            }

            return posts ?? new List<Post>();
        }

        private async Task<IList<Post>> GetAllPosts()
        {
            string jSonPosts = await APIBlogHelper.GetAllPostsAsync();
            IList<Post>? posts = null;

            if (!String.IsNullOrEmpty(jSonPosts))
            {
                posts = JsonConvert.DeserializeObject<IList<Post>>(jSonPosts);
            }

            return posts ?? new List<Post>();
        }

    }
}
