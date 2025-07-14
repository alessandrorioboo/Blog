using ViewModel.ViewModels;

namespace ApplicationBlog.AppService
{
    public interface IAppServicePost
    {
        Task<PagePostViewModel> GetPostsAsync(int items, int page, bool online);
        Task<PagePostViewModel> GetPostsAsyncViewModel(int items, int page, bool online);
    }
}