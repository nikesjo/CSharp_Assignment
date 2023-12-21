using Addressbook.ViewModels;

namespace Addressbook.Views;

public partial class ContactDetailsPage : ContentPage
{
	public ContactDetailsPage(ContactDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}