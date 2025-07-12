using ApplicationBlog.AppService;

namespace Blog
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object? sender, EventArgs e)
        {
            OnCounterClicked(sender ?? this, e);
        }

        //async void OnCounterClicked(object sender, EventArgs e)
        //{
        //    //await _todoService.SaveTaskAsync(TodoItem, _isNewItem);
        //    //await Shell.Current.GoToAsync("..");

        //    CounterBtn.Text = "123";
        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        async void OnCounterClicked(object sender, EventArgs e)
        {
            var online = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

            var appServicePost = new AppServicePost();
            var allPost = await appServicePost.GetPostsAsyncViewModel(10, 1, online);

            if (allPost.Count == 1)
                CounterBtn.Text = $"Clicked {allPost.Count} time. Device is {online}.";
            else
                CounterBtn.Text = $"Clicked {allPost.Count} times. Device is {online}.";


            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
