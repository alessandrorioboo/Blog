using ApplicationBlog.AppService;
using LocalDataBase.Repository;
using Microsoft.Extensions.Logging;

namespace Blog
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IAppServicePost, AppServicePost>();
            builder.Services.AddSingleton<IAppServiceComment, AppServiceComment>();
            builder.Services.AddSingleton<IAppServiceUser, AppServiceUser>();
            builder.Services.AddSingleton<IAppServiceDataInformation, AppServiceDataInformation>();

            builder.Services.AddSingleton<IPostRepository, PostRepository>();
            builder.Services.AddSingleton<ICommentRepository, CommentRepository>();
            builder.Services.AddSingleton<IDataInformationRepository, DataInformationRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            

            builder.Services.AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
