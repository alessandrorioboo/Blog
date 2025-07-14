using ApplicationBlog.AppService;
using ViewModel.ViewModels;

namespace Blog
{
    public partial class MainPage : ContentPage
    {
        IAppServicePost _appServicePost;

        public MainPage(IAppServicePost service)
        {
            InitializeComponent();
            _appServicePost = service;

            Loaded += OnPageLoaded;
        }

        private async void OnPageLoaded(object? sender, EventArgs e)
        {
            var online = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
            this.BindingContext = await _appServicePost.GetPostsAsyncViewModel(10, 1, online);
        }

        public async void OnCommentsClicked(object sender, EventArgs e)
        {
            var post = (PostViewModel)((Button)sender).BindingContext;
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PageCommentViewModel), new PageCommentViewModel { Post = post } }
            };
            await Shell.Current.GoToAsync($"//{nameof(CommentPage)}", navigationParameter);
        }
    }

}
