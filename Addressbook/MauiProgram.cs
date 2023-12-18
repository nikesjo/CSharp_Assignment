using Addressbook.ViewModels;
using Addressbook.Views;
using ClassLibrary.Shared.Services;
using Microsoft.Extensions.Logging;

namespace Addressbook
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AddContactPage>();
            builder.Services.AddSingleton<ContactListPage>();
            builder.Services.AddSingleton<ContactDetailsPage>();
            builder.Services.AddSingleton<UpdateContactPage>();

            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<ContactService>();
            builder.Services.AddSingleton<FileService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
