namespace BankTest.ViewModels;

public partial class BranchesViewModel : BaseViewModel
{
    private readonly ApiService _apiService;
    private bool _isRefreshing;
    private ObservableCollection<Branch> _branches;

    public BranchesViewModel(ApiService apiService)
    {
        _apiService = apiService;
        _branches = new ObservableCollection<Branch>();
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
        var newBranches = await _apiService.GetBranches();
        foreach (var branch in newBranches)
        {
            Branches.Add(branch);
        }
    }

    public async Task LoadDataAsync()
    {
        var branches = await _apiService.GetBranches();
        Branches = new ObservableCollection<Branch>(branches);
    }

    [RelayCommand]
    private async Task GoToDetails(Branch branch)
    {
        await Shell.Current.GoToAsync(nameof(BranchesDetailPage), true, new Dictionary<string, object> { { "Branch", branch } });
    }

    public bool IsRefreshing
    {
        get { return _isRefreshing; }
        set
        {
            if (_isRefreshing != value)
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
    }

    public ObservableCollection<Branch> Branches
    {
        get { return _branches; }
        set
        {
            if (_branches != value)
            {
                _branches = value;
                OnPropertyChanged(nameof(Branches));
            }
        }
    }
}