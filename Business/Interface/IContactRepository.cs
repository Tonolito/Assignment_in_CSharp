using Domain.Dtos;

namespace Business.Interface
{
    public interface IContactRepository
    {
        List<ContactDto>? GetContacts();
        bool SaveContacts(List<ContactDto> contacts);
    }
}