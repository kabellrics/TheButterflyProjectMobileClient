namespace TheButterflyProjectMobileClient.Views;

public partial class MusicPage : ContentPage
{
	public MusicPage(MusicViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
