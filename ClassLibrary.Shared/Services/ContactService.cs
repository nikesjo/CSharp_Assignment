using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace ClassLibrary.Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService = new FileService();
    private List<IContact> _contacts = [];
    private readonly string _filepath = @"D:\Education\csharp\assignment\myfile.json";

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContactToFile(_filepath, json);
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
            var content = _fileService.GetContentFromFile(_filepath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
