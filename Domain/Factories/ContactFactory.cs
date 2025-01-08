using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Factories;

public class ContactFactory : IContactFactory
{
    // instantiate Contact model
    public ContactDto CreateDto()
    {
        return new Dtos.ContactDto();
    }


    public ContactEntity CreateEntity(ContactDto model)
    {
        return new Models.ContactEntity
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


    public Contact CreateContact(ContactEntity contactEntity)
    {
        return new Contact
        {
            Id = contactEntity.Id,
            FirstName = contactEntity.FirstName,
            LastName = contactEntity.LastName,
            Email = contactEntity.Email,
            PhoneNumber = contactEntity .PhoneNumber,
            Adress = contactEntity.Adress,
            ZipCode = contactEntity.ZipCode,
            County = contactEntity.County,

        };
    }


}

