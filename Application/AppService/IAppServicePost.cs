using LocalDataBase.Model;
using ViewModel.ViewModels;

namespace ApplicationBlog.AppService
{
    /// <summary>
    /// Interface de Serviços de Postagens
    /// </summary>
    public interface IAppServicePost
    {
        Task<List<Post>> GetAllPostsPaged(int items, int page);
        Task<PagePostViewModel> GetPostsAsync(int items, int page, bool online);
        Task<PagePostViewModel> GetPostsAsyncViewModel(int items, int page, bool online);
    }
}