using ClassLibrary.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Addressbook.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    public ContactDetailsViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private IContact? _contactDetails;

    [RelayCommand]
    private void GetContactFromList()
    {
        _contactService.GetContactFromList();
        
    }

    [RelayCommand]
    private async Task NavigateToUpdate(IContact contact)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            
        };
        await Shell.Current.GoToAsync("UpdateContactPage");
    }
    //RemoveCommand, navigate to UpdateContact, get and show a specific contact

    [RelayCommand]
    private void RemoveContactFromList(IContact contact)
    {
        _contactService.RemoveContactFromList(contact);
        ContactDetails =
    }
}
