using Business.Helpers;
using Business.Interface;
using Business.Repositories;
using Data.Services;
using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(IContactFactory contactFactory, IContactRepository contactRepository, IIdGenerator idGenerator) : IContactService
{
    private readonly IContactFactory _contactFactory = contactFactory;
    private readonly IContactRepository _contactRepository = contactRepository;
    private readonly IIdGenerator _idGenerator = idGenerator;
    private List<ContactEntity> _contacts = [];

    public bool AddContact(ContactDto dto)
    {
        try
        {
            ContactEntity contactEntity = _contactFactory.CreateEntity(dto);
            contactEntity.Id = _idGenerator.NewId();
            _contacts.Add(contactEntity);
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
            return _contacts.Select(_contactFactory.CreateContact);
        }
        catch
        {
            return [];
        }


    }

    // FUNGERAR EJ
    public bool UpdateContact(Contact contact)
    {
        var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
        if (existingContact != null)
        {
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Adress = contact.Adress;
            existingContact.ZipCode = contact.ZipCode;
            existingContact.County = contact.County;

            _contactRepository.SaveContacts(_contacts);
            return true;
        }
        return false;
    }

    public bool DeleteContact(Contact contact)
    {
        var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
        if (existingContact != null)
        {
            _contacts.Remove(existingContact);

            _contactRepository.SaveContacts(_contacts);
            return true;
        }
        return false;
    }

}
