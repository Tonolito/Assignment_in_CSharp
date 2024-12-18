﻿using Business.Services;
using Domain.Dtos;
using Domain.Factories;
using Domain.Models;

namespace Presentation_Console.Dialogs;

public class AddContactDialog
{
    ContactService contactService = new ContactService();



    public void AddContactMenu()
    {
       ContactModel contactModel =  ContactFactory.CreateModel();


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

        var result = contactService.AddContact(contactModel);


    }


}