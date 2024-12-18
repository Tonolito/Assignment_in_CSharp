namespace Presentation_Console.Dialogs;

public class MainMenuDialog
{
    AddContactDialog AddContactDialog = new AddContactDialog();
    ViewContactDialog ViewContactDialog = new ViewContactDialog();
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

    public  void OptionSwitch(string input)
    {
        switch (input.ToLower())
        {
            case "1":
                AddContactDialog.AddContactMenu();
                break;
            case "2":
                ViewContactDialog.ViewContactMenu();
                break;
            case "3":
                break;
            case "4":
                break;
            case "q":
                break;
            default:
                Console.WriteLine("You need to choose 1, 2, 3, 4, Q");
                break;
        }
    }


}
