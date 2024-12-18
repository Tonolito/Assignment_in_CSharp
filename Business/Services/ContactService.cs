using Business.Helpers;
using Business.Interface;
using Business.Repositories;
using Data.Services;
using Domain.Dtos;
using Domain.Factories;
using Domain.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly ContactRepository _contactRepository = new ContactRepository();
    private List<ContactDto> _contacts;


    public ContactService()
    {

        _contacts = _contactRepository.GetContacts() ?? new List<ContactDto>();

    }

    public bool AddContact(ContactModel model)
    {
        try
        {
            ContactDto contactDto = ContactFactory.CreateDto(model);
            contactDto.Id = IdGenerator.NewId();
            _contacts.Add(contactDto);
            var result = _contactRepository.SaveContacts(_contacts);


            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }


    }
    public IEnumerable<Contact> GetContacts()
    {
        try
        {
            _contacts = _contactRepository.GetContacts()!;
            return _contacts.Select(ContactFactory.CreateContact);
        }
        catch
        {
            return [];
        }


    }

}
