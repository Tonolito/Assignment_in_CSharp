using Domain.Dtos;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContactFactory
    {
        Contact CreateContact(ContactDto contactDto);
        ContactDto CreateDto(ContactModel model);
        ContactModel CreateModel();
    }
}