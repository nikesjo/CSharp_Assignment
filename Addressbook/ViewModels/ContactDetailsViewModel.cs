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
        _contactService.GetContactFromList("");
        
    }
}
