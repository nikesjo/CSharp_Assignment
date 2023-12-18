using ClassLibrary.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Addressbook.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    public MainViewModel(IContactService contactService)
    {
        _contactService = contactService;

        _contactService.ContactsUpdated += (sender, e) =>
        {
            ContactList = new ObservableCollection<IContact>(_contactService.GetContactsFromList());
        };
    }

    [ObservableProperty]
    private ObservableCollection<IContact> contactList = [];

    [RelayCommand]
    private async Task NavigateToAddContact(IContact contact)
    {
        await Shell.Current.GoToAsync("AddContactView");
    }

    [RelayCommand]
    private async Task NavigateToList(IContact contact)
    {
        await Shell.Current.GoToAsync("ContactListView");
    }

    [RelayCommand]
    private async Task NavigateToContactDetails(IContact contact)
    {
        await Shell.Current.GoToAsync("ContactDetailsView");
    }
}
