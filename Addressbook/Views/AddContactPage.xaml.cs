using Addressbook.ViewModels;

namespace Addressbook.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage(AddContactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}