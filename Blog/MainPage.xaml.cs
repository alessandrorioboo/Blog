using ApplicationBlog.AppService;
using System.Collections.ObjectModel;
using ViewModel.ViewModels;
using static Common.Enumerators;

namespace Blog
{
    /// <summary>
    /// Controladora da página de Postagens
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private IAppServicePost _appServicePost;

        private PagePostViewModel _pagePostViewModel = new();
        private const int itemsByPage = 9;
        private const int qtdMaxPages = 5;
        private int starPage = 1;

        public MainPage(IAppServicePost service)
        {
            InitializeComponent();
            _appServicePost = service;
            Loaded += OnPageLoaded;
        }

        private async void OnPageLoaded(object? sender, EventArgs e)
        {
            if (((PagePostViewModel)this.BindingContext).Status == eStatus.Processando)
            {
                await ObterDados(itemsByPage, 1);
                this.BindingContext = _pagePostViewModel;
            }
        }

        public void OnDataRefresh(object sender, EventArgs e)
        {
            _pagePostViewModel.Status = eStatus.Processando;
            Task.Run(() => ObterDados(itemsByPage, 1));
        }

        public void OnPageClicked(object sender, EventArgs e)
        {
            string buttonText = ((Button)sender).Text;

            if (buttonText == "<<")
                RefreshBottonsPages(ePageAction.Anterior);
            else if (buttonText == ">>")
                RefreshBottonsPages(ePageAction.Proximo);
            else
            {
                int page = Convert.ToInt32(((Button)sender).Text);
                _pagePostViewModel.Status = eStatus.Processando;
                Task.Run(() => ObterDados(itemsByPage, page));
            }
        }

        private async Task ObterDados(int items, int page)
        {
            var online = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
            var pagePostViewModel = await _appServicePost.GetPostsAsyncViewModel(items, page, online);
            RefreshViewModel(pagePostViewModel);
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

        public void RefreshViewModel(PagePostViewModel pagePostViewModel)
        {
            _pagePostViewModel.Page = pagePostViewModel.Page;
            _pagePostViewModel.Status = pagePostViewModel.Status;
            _pagePostViewModel.Posts = pagePostViewModel.Posts;
            _pagePostViewModel.Total = pagePostViewModel.Total;
            _pagePostViewModel.Online = pagePostViewModel.Online;
            _pagePostViewModel.LastUpdate = pagePostViewModel.LastUpdate;

            RefreshBottonsPages(ePageAction.Inicial);
        }

        private void RefreshBottonsPages(ePageAction pageAction)
        {
            decimal decimalPages = Convert.ToDecimal(_pagePostViewModel.Total) / Convert.ToDecimal(itemsByPage);
            int qtdPages = Math.Max((int)Math.Ceiling(decimalPages), 1);
            ObservableCollection<PagingViewModel> pages = new();

            switch(pageAction)
            {
                case ePageAction.Anterior:
                    starPage = Math.Max((starPage - qtdMaxPages), 1);
                    break;
                case ePageAction.Proximo:
                    starPage = Math.Max(starPage + qtdMaxPages, 1);
                    break;
            }

            int endPage = Math.Min(starPage + qtdMaxPages - 1, qtdPages);

            if (starPage != 1)
                pages.Add(new PagingViewModel { Page = "<<", IsEnable = true });

            for (var page = starPage; page <= endPage; page++)
            {
                pages.Add(new PagingViewModel { Page = page.ToString(), IsEnable = page != _pagePostViewModel.Page });
            }

            if (endPage < qtdPages)
                pages.Add(new PagingViewModel { Page = ">>", IsEnable = true });

            _pagePostViewModel.Pages = pages;
        }
    }

}
