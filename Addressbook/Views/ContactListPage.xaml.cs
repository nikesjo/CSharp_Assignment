using Addressbook.ViewModels;

namespace Addressbook.Views;

public partial class ContactListPage : ContentPage
{
	public ContactListPage(ContactListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}