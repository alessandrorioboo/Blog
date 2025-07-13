//using Android.Media;
using ApplicationBlog.AppService;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using ViewModel.ViewModels;

namespace Blog
{
    [QueryProperty(nameof(PageCommentViewModel), "PageCommentViewModel")]
    public partial class CommentPage : ContentPage
    {

        PageCommentViewModel pageCommentViewModel;
        public PageCommentViewModel PageCommentViewModel
        {
            get => pageCommentViewModel;
            set
            {
                pageCommentViewModel = value;
                BindingContext = PageCommentViewModel;
                //OnPropertyChanged();
            }
        }
        //IAppServicePost _appServicePost;

        //public CommentPage(IAppServicePost service)
        public CommentPage()
        {
            //BindingContext = PageCommentViewModel;
            InitializeComponent();
            
            //Navigation.PopToRootAsync();
            //_appServicePost = service;

            //Loaded += OnPageLoaded;
        }

        //public CommentPage(Dictionary<string, object> pageCommentViewModel)
        //{
        //    InitializeComponent();
        //    //BindingContext = this;
        //    //Navigation.PopToRootAsync();
        //    //_appServicePost = service;

        //    //Loaded += OnPageLoaded;
        //}


        public async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///MainPage");
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    collectionView.ItemsSource = await null;//await _todoService.GetTasksAsync();
        //}

        //private async void OnPageLoaded(object? sender, EventArgs e)
        //{
        //    //OnCounterClicked(sender ?? this, e);
        //    var online = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        //    this.BindingContext = await _appServicePost.GetPostsAsyncViewModel(10, 1, online);
        //}


    }

}
