using Domain.Models;

namespace Business.Interface
{
    public interface IContactRepository
    {
        List<ContactEntity>? GetContacts();
        bool SaveContacts(List<ContactEntity> contacts);
    }
}