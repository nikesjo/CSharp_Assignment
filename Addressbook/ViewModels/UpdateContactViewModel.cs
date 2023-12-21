using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contact = ClassLibrary.Shared.Models.Contact;

namespace Addressbook.ViewModels;

public partial class UpdateContactViewModel : ObservableObject, IQueryAttributable
{
    private readonly ContactService _contactService;

    public UpdateContactViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private IContact? _updateContactForm;

    [RelayCommand]
    private async Task UpdateContact()
    {
        _contactService.UpdateContact(UpdateContactForm!);
        UpdateContactForm = new Contact();

        await Shell.Current.GoToAsync("..");
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        UpdateContactForm = (query["Contact"] as IContact);
    }
}
