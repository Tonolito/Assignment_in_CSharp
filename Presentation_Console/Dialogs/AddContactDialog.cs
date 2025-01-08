using Business.Interface;
using Business.Services;
using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Presentation_Console.Interfaces;

namespace Presentation_Console.Dialogs;

public class AddContactDialog(IContactFactory contactFactory, IContactService contactService) : IAddContactDialog
{
    private readonly IContactService _contactService = contactService;
    private readonly IContactFactory _contactFactory = contactFactory;

    public void AddContactMenu()
    {
        ContactDto contactDto = _contactFactory.CreateDto();


        Console.Clear();
        Console.WriteLine("--- ADD CONTACT ---");
        Console.WriteLine("Enter your Firstname: ");
        contactDto.FirstName = Console.ReadLine()!;
        Console.WriteLine("Enter your Lastname");
        contactDto.LastName = Console.ReadLine()!;
        Console.WriteLine("Enter your Email");
        contactDto.Email = Console.ReadLine()!;
        Console.WriteLine("Enter your Phonenumber");
        contactDto.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine("Enter your Adress");
        contactDto.Adress = Console.ReadLine()!;
        Console.WriteLine("Enter your Zip code");
        contactDto.ZipCode = Console.ReadLine()!;
        Console.WriteLine("Enter your County");
        contactDto.County = Console.ReadLine()!;

        _contactService.AddContact(contactDto);


    }


}
