using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Factories;

public class ContactFactory : IContactFactory
{
    // instantiate Contact model
    public ContactModel CreateModel()
    {
        return new ContactModel();
    }


    public ContactDto CreateDto(ContactModel model)
    {
        return new ContactDto
        {
            // ID I BUSINESS SERVICE
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Adress = model.Adress,
            ZipCode = model.ZipCode,
            County = model.County,

        };
    }


    public Contact CreateContact(ContactDto contactDto)
    {
        return new Contact
        {
            Id = contactDto.Id,
            FirstName = contactDto.FirstName,
            LastName = contactDto.LastName,
            Email = contactDto.Email,
            PhoneNumber = contactDto.PhoneNumber,
            Adress = contactDto.Adress,
            ZipCode = contactDto.ZipCode,
            County = contactDto.County,

        };
    }


}

