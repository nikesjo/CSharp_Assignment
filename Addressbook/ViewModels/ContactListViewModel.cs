using ClassLibrary.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Addressbook.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    public ContactListViewModel(IContactService contactService)
    {
        _contactService = contactService;
        UpdateContactList();

        _contactService.ContactsUpdated += (sender, e) =>
        {
            UpdateContactList();
        };
    }

    private void UpdateContactList()
    {
        ContactList = new ObservableCollection<IContact>(_contactService.GetContactsFromList());
    }

    [ObservableProperty]
    private ObservableCollection<IContact> contactList = [];

    [RelayCommand]
    private async Task NavigateToAddContact(IContact contact)
    {
        await Shell.Current.GoToAsync("AddContactPage");
    }

    [RelayCommand]
    private async Task NavigateToContactDetails(IContact contact)
    {
        await Shell.Current.GoToAsync("ContactDetailsPage");
    }

    //[RelayCommand]
    //private async Task NavigateToContactDetails(IContact contact)
    //{
    //    var parameters = new ShellNavigationQueryParameters
    //    {
    //        { "ContactInfo", contact }
    //    };
    //    await Shell.Current.GoToAsync("ContactDetailsPage", parameters);
    //}

    [RelayCommand]
    private async Task NavigateToUpdateContact(IContact contact)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            { "ContactInfo", contact }
        };

        await Shell.Current.GoToAsync("UpdateContactPage", parameters);
    }

    [RelayCommand]
    private void RemoveContactFromList(IContact contact)
    {
        _contactService.RemoveContactFromList(contact.Email);
        ContactList = new ObservableCollection<IContact>(_contactService.GetContactsFromList());
    }
}
