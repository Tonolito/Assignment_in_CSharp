using Business.Interface;
using Business.Services;
using Domain.Models;
using Presentation_Console.Interfaces;

namespace Presentation_Console.Dialogs;
// FUNGER EJ
public class UpdateContactDialog(IContactService contactService, IViewContactDialog viewContactDialog) : IUpdateContactDialog
{
    private readonly IContactService _contactService = contactService;
    private readonly IViewContactDialog _viewContactDialog = viewContactDialog;
    
    public void UpdateContactMenu()
    {
        Console.Clear();
        

        _viewContactDialog.ViewContactMenu();
        Console.WriteLine("--- Update Contact ---");

        Console.WriteLine("Write the firstname of the contact you want to update.");
        var input = Console.ReadLine();
       
        foreach(var contact in _contactService.GetContacts())
        {
            if (input == contact!.FirstName)
            {
                Console.WriteLine("What do you want to change?");
                Console.WriteLine($"1. {contact.FirstName}");
                Console.WriteLine($"2. {contact.LastName}");
                Console.WriteLine($"3. {contact.Email}");
                Console.WriteLine($"4. {contact.PhoneNumber}");
                Console.WriteLine($"5. {contact.Adress}");
                Console.WriteLine($"6. {contact.ZipCode}");
                Console.WriteLine($"7. {contact.County}");
                var inputchange = Console.ReadLine();

                switch (inputchange)
                {
                    case "1":
                        Console.WriteLine("Write a new Firstname:");
                        contact.FirstName = Console.ReadLine()!;
                        break;

                    case "2":
                        Console.WriteLine("Write a new Lastname:");
                        contact.LastName = Console.ReadLine()!;
                        break;

                    case "3":
                        Console.WriteLine("Write a new Email:");
                        contact.Email = Console.ReadLine()!;
                        break;

                    case "4":
                        Console.WriteLine("Write a new Phonenumber:");
                        contact.PhoneNumber = Console.ReadLine()!;
                        break;

                    case "5":
                        Console.WriteLine("Write a new Address:");
                        contact.Adress = Console.ReadLine()!;
                        break;

                    case "6":
                        Console.WriteLine("Write a new Zipcode:");
                        contact.ZipCode = Console.ReadLine()!;
                        break;

                    case "7":
                        Console.WriteLine("Write a new County:");
                        contact.County = Console.ReadLine()!;
                        break;

                    default:
                        Console.WriteLine("Not a valid option. Choose 1, 2, 3, 4, 5, 6, or 7.");
                        break;
                }
                _contactService.UpdateContact(contact);
            }
            else
            {
                Console.WriteLine("Check you spelling");
            }
        }

    }

}
