﻿using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Models;
using ConsoleApp_AddressBook.Interfaces;

namespace ConsoleApp_AddressBook.Services;

public class MenuService : IMenuService
{
    private readonly IContactService _contactService;

    public MenuService(IContactService contactService)
    {
        _contactService = contactService;
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("### Address Book ###\n");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Search a specific contact");
            Console.WriteLine("4. Remove a specific contact");
            Console.WriteLine("5. Exit\n");

            Console.Write("Enter option: ");
            var option = Console.ReadLine(); 

            switch (option)
            {
                case "1":
                    AddContactMenu();
                    break;
                case "2":
                    ShowAllContactsMenu();
                    break;
                case "3":
                    ShowContactMenu();
                    break;
                case "4":
                    ShowRemoveContactMenu();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    public void AddContactMenu()
    {
        Console.Clear();
        Console.WriteLine("### Add a contact ###\n");

        IContact contact = new Contact();

        Console.Write("Enter your first name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter your phone number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter your address: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Enter your postal code: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        contact.City = Console.ReadLine()!;

        _contactService.AddContactToList(contact);

        Console.WriteLine();
        Console.WriteLine("Contact successfully added!");

        Console.WriteLine();
        Console.WriteLine("Press enter to continue...");
    }

    public void ShowAllContactsMenu()
    {
        Console.Clear();
        Console.WriteLine("### All contacts ###");

        var contacts = _contactService.GetContactsFromList();

        if (contacts != null && contacts.Any())
        {
            int count = 1;
            foreach (var contact in contacts)
            {
                Console.WriteLine();
                Console.WriteLine($"{count}. ");
                Console.WriteLine($"{contact.FirstName} {contact.LastName} ");
                Console.WriteLine($"Phone number: {contact.PhoneNumber} ");
                Console.WriteLine($"Email: {contact.Email} ");
                Console.WriteLine($"Address: {contact.Address} {contact.PostalCode} {contact.City} ");

                count++;
            }
        }
        else
        {
            Console.WriteLine("No contacts was found");
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to continue...");
    }

    public void ShowContactMenu()
    {
        Console.Clear();
        Console.WriteLine("### Show a specific contact ###");

        Console.Write("Type the email address of the contact you want to retrieve: ");
        var email = Console.ReadLine();

        if (!string.IsNullOrEmpty(email))
        {
            var contact = _contactService.GetContactFromList(email);

            Console.WriteLine();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} ");
            Console.WriteLine($"Phone number: {contact.PhoneNumber} ");
            Console.WriteLine($"Email: {contact.Email} ");
            Console.WriteLine($"Address: {contact.Address} {contact.PostalCode} {contact.City} ");
        }
        else
        {
            Console.WriteLine("No contact was found.");
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to continue...");
    }

    public void ShowRemoveContactMenu()
    {
        Console.Clear();
        Console.WriteLine("### Remove a contact ###\n");

        Console.Write("Enter the email address of the contact to remove: ");
        string emailToRemove = Console.ReadLine()!;

        if (_contactService.RemoveContactFromList(emailToRemove))
        {
            Console.WriteLine("Contact removed successfully.");
        }
        else
        {
            Console.WriteLine("No contact was found.");
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to continue...");
    }
}
