using ApplicationBlog.Helper;
using LocalDataBase.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace ApplicationBlog.AppService
{
    public class AppServicePost : AppServiceBase, IAppServicePost
    {
        public async Task<PagePostViewModel> GetPostsAsyncViewModel(int itens, int page, bool online)
        {
            var pagePostViewModel = await GetPostsAsync(itens, page, online);

            return pagePostViewModel;
        }

        public async Task<PagePostViewModel> GetPostsAsync(int itens, int page, bool online)
        {
            PagePostViewModel pagePostViewModel = new PagePostViewModel
            {
                Page = page,
                Total = 0,
                Posts = null,
                Status = "Processando"
            };

            try
            {
                var posts = await GetAllPosts();

                pagePostViewModel.Total = posts.Count;

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

                    // Fake para testar Postagens sem Comentários
                    var removeCommentsPostId = posts == null ? 0 : posts.First().Id;
                    comments = comments.Where(p => p.PostId != removeCommentsPostId).ToList();

                    posts = (from post in posts
                             join user in users
                             on post.UserId equals user.Id
                             select new Post(post, user, comments.Where(comment => comment.PostId == post.Id).ToList())).OrderByDescending(p => p.Id).ToList();


                    MapperHelper<IList<Post>, IList<PostViewModel>> mapperHelper = new MapperHelper<IList<Post>, IList<PostViewModel>>();
                    var postsViewModel = mapperHelper.Map(posts);

                    //var jSonPosts = JsonSerializer.Serialize(posts, _serializerOptions);
                    //var postsViewModel = JsonSerializer.Deserialize<IList<PostViewModel>>(jSonPosts, _serializerOptions);


                    pagePostViewModel.Posts = postsViewModel;
                    pagePostViewModel.Status = "OK";
                }
            }
            catch (Exception)
            {
                pagePostViewModel.Total = 0;
                pagePostViewModel.Page = 0;
                pagePostViewModel.Status = "Erro";
                pagePostViewModel.Posts = null;
            }

            return pagePostViewModel;
        }

        private async Task<IList<Post>> GetAllPosts()
        {
            string jSonPosts = await APIBlogHelper.GetAllPostsAsync();
            IList<Post>? posts = null;

            if (!String.IsNullOrEmpty(jSonPosts))
            {
                posts = JsonSerializer.Deserialize<IList<Post>>(jSonPosts, _serializerOptions);
            }

            return posts ?? new List<Post>();
        }

    }
}
