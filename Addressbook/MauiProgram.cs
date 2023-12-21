using Addressbook.ViewModels;
using Addressbook.Views;
using ClassLibrary.Shared.Interfaces;
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

            builder.Services.AddSingleton<ContactListPage>();
            builder.Services.AddSingleton<ContactListViewModel>();

            builder.Services.AddSingleton<AddContactPage>();
            builder.Services.AddSingleton<AddContactViewModel>();

            builder.Services.AddSingleton<ContactDetailsPage>();
            builder.Services.AddSingleton<ContactDetailsViewModel>();

            builder.Services.AddSingleton<UpdateContactPage>();
            builder.Services.AddSingleton<UpdateContactViewModel>();

            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<IFileService, FileService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
