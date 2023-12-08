using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Services;

namespace ConsoleApp_AddressBook.Services;

public class MenuService
{
    private readonly IContactService _contactService = new ContactService();

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu\n");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Search a specific contact");
            Console.WriteLine("4. Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowMainMenu();
                    break;
                case "2":
                    ShowMainMenu();
                    break;
                case "3":
                    ShowMainMenu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again");
                    break;
            }

            Console.ReadKey();
        }
    }
}
