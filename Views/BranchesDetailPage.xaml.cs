namespace BankTest.Views;

public partial class BranchesDetailPage : ContentPage
{
	public BranchesDetailPage(BranchesDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
