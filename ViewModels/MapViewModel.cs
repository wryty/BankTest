namespace BankTest.ViewModels;

public partial class MapViewModel : BaseViewModel
{
    private readonly TestLocationService locationService;
    private Location location;

    public MapViewModel(TestLocationService locationService)
    {
        this.locationService = locationService;
        LoadLocation();
    }

    [RelayCommand]
    public async Task LoadLocation()
    {
        location = await locationService.GetCurrentLocation();

    }

    [RelayCommand]
    public void LoadLocation2()
    {

    }
}
