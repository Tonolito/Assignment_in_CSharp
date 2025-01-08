using Domain.Dtos;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContactFactory
    {
        

        ContactDto CreateDto();
        ContactEntity CreateEntity(ContactDto model);

        Contact CreateContact(ContactEntity contactEntity);
    }
}