﻿namespace Domain.Models;

// Model of a Contact
public class ContactModel
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
    public string Adress { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string County { get; set; } = null!;
}


//  förnamn, efternamn, e-postadress, telefonnummer, gatuadress, postnummer och ort.