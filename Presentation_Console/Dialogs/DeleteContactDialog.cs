using Business.Interface;
using Business.Services;
using Domain.Models;
using Presentation_Console.Interfaces;

namespace Presentation_Console.Dialogs;

public class DeleteContactDialog(IContactService contactService, IViewContactDialog viewContactDialog) : IDeleteContactDialog
{
    private readonly IContactService _contactService = contactService;
    private readonly IViewContactDialog _viewContactDialog = viewContactDialog;
    public void DeleteContactMenu()
    {
        Console.Clear();


        _viewContactDialog.ViewContactMenu();
        Console.WriteLine("--- Delete Contact ---");

        Console.WriteLine("Write the firstname of the contact you want to Delete.");
        var input = Console.ReadLine();
        foreach (var contact in _contactService.GetContacts())
        {
            if (input == contact!.FirstName)
            {
                // FUNGERAR MEN KRACHAR
                _contactService.DeleteContact(contact);


            }
            else
            {
                Console.WriteLine("Check you spelling");
            }
        }
    }
}
