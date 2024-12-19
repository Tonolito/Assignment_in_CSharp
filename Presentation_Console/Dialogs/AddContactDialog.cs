using Business.Interface;
using Business.Services;
using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;
using Presentation_Console.Interfaces;

namespace Presentation_Console.Dialogs;

public class AddContactDialog(IContactFactory contactFactory, IContactService contactService) : IAddContactDialog
{
    private readonly IContactService _contactService = contactService;
    private readonly IContactFactory _contactFactory = contactFactory;

    public void AddContactMenu()
    {
        ContactModel contactModel = _contactFactory.CreateModel();


        Console.Clear();
        Console.WriteLine("--- ADD CONTACT ---");
        Console.WriteLine("Enter your Firstname: ");
        contactModel.FirstName = Console.ReadLine()!;
        Console.WriteLine("Enter your Lastname");
        contactModel.LastName = Console.ReadLine()!;
        Console.WriteLine("Enter your Email");
        contactModel.Email = Console.ReadLine()!;
        Console.WriteLine("Enter your Phonenumber");
        contactModel.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine("Enter your Adress");
        contactModel.Adress = Console.ReadLine()!;
        Console.WriteLine("Enter your Zip code");
        contactModel.ZipCode = Console.ReadLine()!;
        Console.WriteLine("Enter your County");
        contactModel.County = Console.ReadLine()!;

        _contactService.AddContact(contactModel);


    }


}
