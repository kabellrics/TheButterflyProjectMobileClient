namespace TheButterflyProjectMobileClient.Views;

public partial class SynchroPage : ContentPage
{
	public SynchroPage(SynchroViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
