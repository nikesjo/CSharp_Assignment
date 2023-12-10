//using Microsoft.Extensions.Hosting;


//var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
//{

//}).Build();
using ConsoleApp_AddressBook.Services;

var menuService = new MenuService();

menuService.ShowMainMenu();