using ClassLibrary.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Addressbook.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly IContactService _contactService;

    public ContactDetailsViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private IContact? _contactDetails;

    [RelayCommand]
    public void GetContactFromList()
    {
        _contactService.GetContactFromList(ContactDetails!.Email);
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ContactDetails = (query["ContactInfo"] as IContact);
    }
}
