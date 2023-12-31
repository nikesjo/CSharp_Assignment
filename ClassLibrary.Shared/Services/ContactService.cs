﻿using ClassLibrary.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;


namespace ClassLibrary.Shared.Services;

public class ContactService : IContactService
{
    private List<IContact> _contacts;
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService)
    {
        _contacts = new List<IContact>();
        _fileService = fileService;
    }

    public event EventHandler? ContactsUpdated;

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented });

                var result = _fileService.SaveContactToFile(json);
                ContactsUpdated?.Invoke(this, EventArgs.Empty);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public IContact GetContactFromList(string email)
    {
        try
        {
            GetContactsFromList();

            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<IContact> GetContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public void UpdateContact(IContact contact)
    {
        try
        {
            var item = _contacts.FirstOrDefault(x => x.Email == contact.Email);
            if (item != null)
            {
                item = contact;
                _fileService.UpdateContactListToFile(_contacts);
                ContactsUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public bool RemoveContactFromList(string email)
    {
        try
        {
            GetContactsFromList();

            var contactToRemove = _contacts.FirstOrDefault(x => x.Email == email);
            if (contactToRemove != null)
            {
                _contacts.Remove(contactToRemove);

                var result = _fileService.UpdateContactListToFile(_contacts);
                ContactsUpdated?.Invoke(this, EventArgs.Empty);

                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
