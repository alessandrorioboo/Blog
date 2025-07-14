using ApplicationBlog.Helper;
using LocalDataBase.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using ViewModel.ViewModels;
using static Common.Enumerators;

namespace ApplicationBlog.AppService
{
    public class AppServicePost : AppServiceBase, IAppServicePost
    {
        public async Task<PagePostViewModel> GetPostsAsyncViewModel(int items, int page, bool online)
        {
            var pagePostViewModel = await GetPostsAsync(items, page, online);

            return pagePostViewModel;
        }

        public async Task<PagePostViewModel> GetPostsAsync(int items, int page, bool online)
        {
            PagePostViewModel pagePostViewModel = new PagePostViewModel
            {
                Page = page,
                Total = 0,
                Posts = null,
                Status = eStatus.Processando
            };

            try
            {
                var posts = await GetAllPosts();

                pagePostViewModel.Total = posts.Count;

                posts = posts.OrderByDescending(p => p.Id).Skip((page - 1) * items).Take(items).ToList();

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


                    MapperHelper<List<Post>, ObservableCollection<PostViewModel>> mapperHelper = new MapperHelper<List<Post>, ObservableCollection<PostViewModel>>();
                    var postsViewModel = mapperHelper.Map(posts);

                    pagePostViewModel.Posts = postsViewModel;
                    pagePostViewModel.Status = eStatus.OK;
                }
            }
            catch (Exception)
            {
                pagePostViewModel.Total = 0;
                pagePostViewModel.Page = 0;
                pagePostViewModel.Status = eStatus.Erro;
                pagePostViewModel.Posts = null;
            }

            return pagePostViewModel;
        }

       
        private async Task<List<Post>> GetAllPosts()
        {
            string jSonPosts = await APIBlogHelper.GetAllPostsAsync();
            List<Post>? posts = null;

            if (!String.IsNullOrEmpty(jSonPosts))
            {
                posts = JsonSerializer.Deserialize<List<Post>>(jSonPosts, _serializerOptions);
            }

            return posts ?? new List<Post>();
        }

    }
}
