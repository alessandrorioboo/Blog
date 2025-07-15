using ViewModel.ViewModels;

namespace Blog
{
    /// <summary>
    /// Controladora da página de Comentários
    /// </summary>
    [QueryProperty(nameof(PageCommentViewModel), "PageCommentViewModel")]
    public partial class CommentPage : ContentPage
    {

        PageCommentViewModel pageCommentViewModel = new PageCommentViewModel();
        public PageCommentViewModel PageCommentViewModel
        {
            get => pageCommentViewModel;
            set
            {
                pageCommentViewModel = value;
                BindingContext = PageCommentViewModel;
            }
        }

        public CommentPage()
        {
            InitializeComponent();
        }

        public async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }

}
