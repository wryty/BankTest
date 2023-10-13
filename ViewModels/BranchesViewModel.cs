namespace BankTest.ViewModels;
public partial class BranchesViewModel : BaseViewModel
{
    readonly ApiService dataService;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<Branch> items;

    public BranchesViewModel()
    {
        dataService = new ApiService();
    }

    [RelayCommand]
    private async Task OnRefreshing()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task LoadMore()
    {
        var items = await dataService.GetBranches();
    
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }

    public async Task LoadDataAsync()
    {
        Items = new ObservableCollection<Branch>(await dataService.GetBranches());
    }

    [RelayCommand]
    private async Task GoToDetails(Branch item)
    {
        await Shell.Current.GoToAsync(nameof(BranchesDetailPage), true, new Dictionary<string, object>
        {
            { "Item", item }
        });
    }
}