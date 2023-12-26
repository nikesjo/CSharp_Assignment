﻿using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Services;
using ConsoleApp_AddressBook.Interfaces;
using ConsoleApp_AddressBook.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IFileService>(new FileService(@"D:\Education\csharp\assignment\contactfile.json"));
    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<IMenuService, MenuService>();
}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<IMenuService>();
menuService.ShowMainMenu();