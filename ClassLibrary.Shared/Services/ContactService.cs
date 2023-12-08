using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Models;

namespace ClassLibrary.Shared.Services;

public class ContactService : IContactService
{
    private List<Contact> _contactlist = [];

    public bool AddContactToList(IContact contact)
    {
        return true;
    }

    public IContact GetContactFromList(string email)
    {
        return null!;
    }

    public IEnumerable<IContact> GetContactsFromList()
    {
        return null!;
    }
}
