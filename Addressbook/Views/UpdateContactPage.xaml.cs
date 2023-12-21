using Addressbook.ViewModels;

namespace Addressbook.Views;

public partial class UpdateContactPage : ContentPage
{
	public UpdateContactPage(UpdateContactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}