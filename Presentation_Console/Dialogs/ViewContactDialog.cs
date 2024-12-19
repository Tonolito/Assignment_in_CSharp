using Business.Interface;
using Business.Services;
using Presentation_Console.Interfaces;

namespace Presentation_Console.Dialogs;

public class ViewContactDialog(IContactService contactService) : IViewContactDialog
{
    private readonly IContactService _contactService = contactService;

    public void ViewContactMenu()
    {
        Console.Clear();
        Console.WriteLine("--- CONTACT LIST ---");

        foreach (var contact in _contactService.GetContacts())
        {

            Console.WriteLine("");
            Console.WriteLine($"{contact.Id}");
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{contact.Email}");
            Console.WriteLine($"{contact.PhoneNumber}");
            Console.WriteLine($"{contact.Adress}");
            Console.WriteLine($"{contact.ZipCode} {contact.County}");

        }
        Console.ReadKey();
    }


}
