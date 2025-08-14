using TravelNurseServer.Dtos.Providers.Get;

namespace TravelNurse.Components.Pages.Providers;

public class ProviderProfileStore
{
    public event Action? StateChanged;
    
    public GetProviderDto? Provider { get; private set; }
    
    public void SetProvider(GetProviderDto provider)
    {
        Provider = provider;
        NotifyStateChanged();
    }
    
    private void NotifyStateChanged() => StateChanged?.Invoke();
}