using ApplicationBlog.AppService;

namespace Blog
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
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
            count++;

            var appServiceBlog = new AppServiceBlog();
            var todo = await appServiceBlog.GetClicks(count);

            var online = Connectivity.Current.NetworkAccess == NetworkAccess.Internet ? "Online" : "Offline";


            if (todo.Id == 1)
                CounterBtn.Text = $"Clicked {todo.Id} time. Device is {online}.";
            else
                CounterBtn.Text = $"Clicked {todo.Id} times. Device is {online}.";




            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
