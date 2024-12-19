// Init

using Business.Helpers;
using Business.Interface;
using Business.Repositories;
using Business.Services;
using Data.Interfaces;
using Data.Services;
using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_Console.Dialogs;
using Presentation_Console.Interfaces;
using System.Text.Json;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((config, services) =>
    {
        services.AddSingleton<IContactRepository, ContactRepository>();
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IIdGenerator, IdGenerator>();
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IContactFactory, ContactFactory>();
        services.AddSingleton<IAddContactDialog, AddContactDialog>();
        services.AddSingleton<IViewContactDialog, ViewContactDialog>();
        services.AddSingleton<IUpdateContactDialog, UpdateContactDialog>();
        services.AddSingleton<IMainMenuDialog, MainMenuDialog>();
        
        
        

    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var mainMenuDialog = scope.ServiceProvider.GetRequiredService<IMainMenuDialog>();
    mainMenuDialog.Run();
}


