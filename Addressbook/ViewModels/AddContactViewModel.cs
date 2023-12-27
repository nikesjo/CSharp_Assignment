using ClassLibrary.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact = ClassLibrary.Shared.Models.Contact;

namespace Addressbook.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    public AddContactViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private IContact _addContactForm = new Contact();

    [RelayCommand]
    private async Task AddContactToList()
    {
        _contactService.AddContactToList(AddContactForm);
        AddContactForm = new Contact();

        await Shell.Current.GoToAsync("..");
    }
}
