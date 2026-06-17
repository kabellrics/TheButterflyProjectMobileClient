using CommunityToolkit.Maui.Core.Primitives;
using IntelliJ.Lang.Annotations;
using TheButterflyProjectMobileClient.Contracts;
using TheButterflyProjectMobileClient.DAL;
using TheButterflyProjectMobileClient.Models;
using TheButterflyProjectMobileClient.Services.Http;

namespace TheButterflyProjectMobileClient.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServerEndpointProvider _serverEndpointProvider;

    [ObservableProperty]
    private ObservableCollection<Setting> _settings;

    [ObservableProperty]
    private string serverAddress;

    [ObservableProperty]
    private string statusMessage;

    [ObservableProperty]
    private Brush statusColor;

    public SettingsViewModel(
     IUnitOfWork unitOfWork
        , IServerEndpointProvider serverEndpointProvider)
    {
        _serverEndpointProvider = serverEndpointProvider;
        _unitOfWork = unitOfWork;
        _ = LoadingPage();
    }
    private async Task LoadingPage()
    {
        ServerAddress = _serverEndpointProvider.ServerAdressString;
        Settings.Clear();
        foreach (var set in await _unitOfWork.Repository<Setting>().GetAllAsync())
            Settings.Add(set);
    }
}
