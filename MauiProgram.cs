using Anacrusa.Data;
using Anacrusa.Repository;
using Microsoft.Extensions.Logging;

namespace Anacrusa
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
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoVariable");
                });


            // SERVICES
            builder.Services.AddSingleton<AppDatabase>( sp =>
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "anacrusa.db3");
                return new AppDatabase(dbPath);
            });

            builder.Services.AddSingleton<IBookmarkRepository, BookmarkRepository>();
            builder.Services.AddSingleton<ISetlistRepository, SetListRepository>();
            builder.Services.AddSingleton<ISetlistItemRepository, SetListItemsRepository>();
            builder.Services.AddSingleton<IScoreRepository, ScoreRepository>();




#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();


        }
    }
}
