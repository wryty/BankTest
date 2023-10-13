namespace BankTest.Views;

public partial class BranchesPage : ContentPage
{
	BranchesViewModel ViewModel;

	public BranchesPage(BranchesViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
