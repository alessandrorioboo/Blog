using ViewModel.ViewModels;

namespace ApplicationBlog.AppService
{
    public interface IAppServicePost
    {
        Task<PagePostViewModel> GetPostsAsync(int itens, int page, bool online);
        Task<PagePostViewModel> GetPostsAsyncViewModel(int itens, int page, bool online);
    }
}