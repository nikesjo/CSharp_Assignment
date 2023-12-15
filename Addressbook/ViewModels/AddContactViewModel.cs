﻿using ClassLibrary.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
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
    private Contact _addContactForm = new();

    [ObservableProperty]
    private ObservableCollection<Contact> _contactList = [];

    public void AddContactToList()
    {

    }
}
