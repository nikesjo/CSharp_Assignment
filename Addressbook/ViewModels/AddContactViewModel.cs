using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact = ClassLibrary.Shared.Models.Contact;

namespace Addressbook.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    //Borde detta vara IContactService?
    private readonly ContactService _contactService;

    //Borde detta vara IContactService?
    public AddContactViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private IContact _addContactForm = new();

    [RelayCommand]
    private async Task AddContactToList()
    {
        _contactService.AddContactToList(AddContactForm);
        AddContactForm = new();

        await Shell.Current.GoToAsync("..");
    }
}
