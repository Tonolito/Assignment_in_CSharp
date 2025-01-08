using Domain.Dtos;
using Domain.Models;

namespace Business.Interface
{
    public interface IContactService
    {
        bool AddContact(ContactDto model);
        IEnumerable<Contact> GetContacts();

        bool UpdateContact(Contact contact);

        public bool DeleteContact(Contact contact);

    }
}