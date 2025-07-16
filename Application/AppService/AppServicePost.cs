using ApplicationBlog.Helper;
using LocalDataBase.Model;
using LocalDataBase.Repository;
using System.Collections.ObjectModel;
using System.Text.Json;
using ViewModel.ViewModels;
using static Common.Enumerators;

namespace ApplicationBlog.AppService
{
    /// <summary>
    /// Classe de Serviços de Postagens
    /// </summary>
    public class AppServicePost : AppServiceBase, IAppServicePost
    {
        private IPostRepository _postRepository;
        private IAppServiceComment _appServiceComment;
        private IAppServiceUser _appServiceUser;
        private IAppServiceDataInformation _appServiceDataInformation;
        
        //TODO: Por questões de testes foram criados 2 modos de persistência de dados para consumo offline. Base Cheia/Base Reduzida.
        private bool _modoBaseCheia = true;

        public AppServicePost(IPostRepository postRepository, IAppServiceComment appServiceComment, IAppServiceUser appServiceUser, IAppServiceDataInformation appServiceDataInformation)
        {
            _postRepository = postRepository;
            _appServiceComment = appServiceComment;
            _appServiceUser = appServiceUser;
            _appServiceDataInformation = appServiceDataInformation;
        }

        public async Task<PagePostViewModel> GetPostsAsyncViewModel(int items, int page, bool online)
        {
            var pagePostViewModel = await GetPostsAsync(items, page, online);

            return pagePostViewModel;
        }

        public async Task<List<Post>> GetAllPostsPaged(int items, int page)
        {
            var posts = await _postRepository.GetAllPostsPaged(items, page);

            if (!posts.Where(p => p.Comments != null).Any())
            {
                var comments = await _appServiceComment.GetCommentsInPostIdList(posts.Select(posts => posts.Id).ToList());
                posts = (from post in posts
                         select new Post(post, post.User ?? new User(), comments.Where(comment => comment.PostId == post.Id).ToList())).OrderByDescending(p => p.Id).ToList();

            }

            if (!posts.Where(p => p.User != null).Any())
            {
                var users = await _appServiceUser.GetUserInUserIdList(posts.Select(posts => posts.UserId).Distinct().ToList());
                posts = (from post in posts
                         join user in users
                         on post.UserId equals user.Id
                         select new Post(post, user, post.Comments ?? new List<Comment>())).OrderByDescending(p => p.Id).ToList();
            }

            return posts;
        }


        public async Task<PagePostViewModel> GetPostsAsync(int items, int page, bool online)
        {
            PagePostViewModel pagePostViewModel = new PagePostViewModel
            {
                Page = page,
                Total = 0,
                Posts = null,
                Status = eStatus.Processando,
                Online = online
            };

            try
            {
                List<Post> posts;
                if (online)
                {
                    posts = await GetAllPosts();
                    pagePostViewModel.Total = posts.Count;
                    pagePostViewModel.LastUpdate = DateTime.Now;
                    if (!_modoBaseCheia)
                    {
                        posts = posts.OrderByDescending(p => p.Id).Skip((page - 1) * items).Take(items).ToList();
                    }
                }
                else
                {
                    var dataInformation = await _appServiceDataInformation.GetFirst();
                    pagePostViewModel.Total = await _postRepository.GetQttRows();
                    pagePostViewModel.LastUpdate = dataInformation.LastUpdate;

                    posts = await GetAllPostsPaged(items, page);
                }

                if (online)
                {
                    var userIdList = posts.Select(p => p.UserId).Distinct().ToList();
                    var usersTask = _appServiceUser.GetUsersByListIdAsync(userIdList);

                    var postIdList = posts.Select(p => p.Id).Distinct().ToList();
                    var commentsTask = _appServiceComment.GetCommentsByPostListIdAsync(postIdList);

                    var users = await usersTask;
                    var comments = await commentsTask;

                    //TODO: Fake para testar postagens sem comentários
                    comments = comments.Where(p => p.PostId != 100).ToList();

                    posts = (from post in posts
                             join user in users
                             on post.UserId equals user.Id
                             select new Post(post, user, comments.Where(comment => comment.PostId == post.Id).ToList())).OrderByDescending(p => p.Id).ToList();

                    var postsCopy = posts;

                    if (_modoBaseCheia)
                    {
                        Task.Run(() => SaveLocalDataBaseCheia(postsCopy));
                        posts = posts.OrderByDescending(p => p.Id).Skip((page - 1) * items).Take(items).ToList();
                    }
                    else
                    {
                        Task.Run(() => SaveLocalDataReduzida(postsCopy));
                    }
                }

                MapperHelper<List<Post>, ObservableCollection<PostViewModel>> mapperHelper = new MapperHelper<List<Post>, ObservableCollection<PostViewModel>>();
                var postsViewModel = mapperHelper.Map(posts);

                pagePostViewModel.Posts = postsViewModel;
                pagePostViewModel.Status = eStatus.OK;
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

        private async Task SaveLocalDataBaseCheia(List<Post> posts)
        {
            await RemoveAllData();

            await _postRepository.AddAll(posts);

            var dataInformation = new DataInformation { Id = 1, LastUpdate = DateTime.Now };
            await _appServiceDataInformation.AddOrUpdate(dataInformation);
        }

        private async Task SaveLocalDataReduzida(List<Post> posts)
        {
            await _postRepository.AddOrUpdateAll(posts);

            DataInformation dataInformation = new DataInformation { LastUpdate = DateTime.Now };
            await _appServiceDataInformation.AddOrUpdate(dataInformation);
        }

        public async Task RemoveAllData()
        {
            await _postRepository.RemoveAll();
            await _appServiceComment.RemoveAll();
            await _appServiceUser.RemoveAll();
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
