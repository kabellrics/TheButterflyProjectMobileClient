using Microsoft.EntityFrameworkCore;
using TheButterflyProjectMobileClient.Contracts;
using TheButterflyProjectMobileClient.DAL;
using TheButterflyProjectMobileClient.Models;
using TheButterflyProjectMobileClient.Services.Http;

namespace TheButterflyProjectMobileClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialSymbol");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddDbContext<AppDbContext>(
            options => 
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "butterfly.db");
                options.UseSqlite($"Filename={dbPath}");
            });

        builder.Services.AddSingleton<IServerEndpointProvider, ServerEndpointProvider>();
        builder.Services.AddHttpClient();
        builder.Services.AddSingleton<RestClientFactory>();
        builder.Services.AddSingleton<RestEndpointRegistry>(sp =>
        {
            var registry = new RestEndpointRegistry();
            registry.Register<Artiste>("/api/Artiste");
            registry.Register<Album>("/api/Albums");
            registry.Register<ArtisteMorceau>("/api/ArtisteMorceau");
            registry.Register<Collection>("/api/Collection");
            registry.Register<Morceau>("/api/Morceau");
            registry.Register<Playlist>("/api/Playlist");
            registry.Register<PlaylistMorceau>("/api/PlaylistMorceau");
            registry.Register<Serie>("/api/Serie");
            registry.Register<Setting>("/api/Setting");
            registry.Register<Tome>("/api/Tome");
            registry.Register<TodoList>("/api/TodoList");
            registry.Register<TodoItem>("/api/TodoItem");

            return registry;
        });


        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddSingleton<HomeViewModel>();

		builder.Services.AddSingleton<LibraryViewModel>();

		builder.Services.AddSingleton<MusicViewModel>();

		builder.Services.AddSingleton<SettingsViewModel>();

		builder.Services.AddSingleton<SynchroViewModel>();

		return builder.Build();
	}
}
