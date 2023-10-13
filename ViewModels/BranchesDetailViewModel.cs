namespace BankTest.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class BranchesDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	Branch item;
}
