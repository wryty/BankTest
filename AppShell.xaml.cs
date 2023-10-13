namespace BankTest;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(BranchesDetailPage), typeof(BranchesDetailPage));
	}
}
