namespace ClassLibrary.Shared.Interfaces;

internal interface IContactService
{
    bool AddContactToList(IContact contact);
    IEnumerable<IContact> GetContactsFromList();
    IContact GetContactFromList(string email);
}
