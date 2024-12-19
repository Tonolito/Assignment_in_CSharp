using Domain.Models;

namespace Business.Interface
{
    public interface IContactService
    {
        bool AddContact(ContactModel model);
        IEnumerable<Contact> GetContacts();

        bool UpdateContact(Contact contact);

    }
}