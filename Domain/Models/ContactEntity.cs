﻿using Domain.Interfaces;

namespace Domain.Models;

public class ContactEntity : IContactEntity
{

    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
    public string Adress { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string County { get; set; } = null!;

}



