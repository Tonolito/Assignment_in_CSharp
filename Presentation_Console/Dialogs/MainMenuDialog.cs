﻿using Presentation_Console.Interfaces;

namespace Presentation_Console.Dialogs;

public class MainMenuDialog(IAddContactDialog addContactDialog, IViewContactDialog viewContactDialog,IUpdateContactDialog updateContactDialog, IDeleteContactDialog deleteContactDialog) : IMainMenuDialog
{
    private readonly IAddContactDialog _AddContactDialog = addContactDialog;
    private readonly IViewContactDialog _viewContactDialog = viewContactDialog;
    private readonly IUpdateContactDialog _updateContactDialog = updateContactDialog;
    private readonly IDeleteContactDialog _deleteContactDialog = deleteContactDialog;
    public void Run()
    {
        while (true)
        {
            MainMenu();
            var input = Console.ReadLine();
            OptionSwitch(input!);
        }


    }


    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to your Contact book!");
        Console.WriteLine("1. Add Contact");
        Console.WriteLine("2. View Contacts");
        Console.WriteLine("3. Update Contact");
        Console.WriteLine("4. Delete Contact");
        Console.WriteLine("Q. Quit");
        Console.WriteLine("");



    }

    public void OptionSwitch(string input)
    {
        switch (input.ToLower())
        {
            case "1":
                _AddContactDialog.AddContactMenu();
                break;
            case "2":
                _viewContactDialog.ViewContactMenu();
                Console.ReadKey();
                break;
            case "3":
                _updateContactDialog.UpdateContactMenu();
                break;
            case "4":
                _deleteContactDialog.DeleteContactMenu();
                break;
            case "q":
                System.Environment.Exit(1);
                break;
            default:
                Console.WriteLine("You need to choose 1, 2, 3, 4, Q");
                Console.ReadKey();
                break;
        }
    }


}
