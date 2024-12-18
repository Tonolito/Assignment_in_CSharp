using Business.Interface;
using Data.Services;
using Domain.Dtos;
using System.Text.Json;

namespace Business.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly FileService _fileService = new FileService();
    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };



    public bool SaveContacts(List<ContactDto> contacts)
    {
        try
        {
            var json = JsonSerializer.Serialize(contacts, _jsonSerializerOptions);
            _fileService.SaveContactToFile(json);

            return true;
        }
        catch
        {
            return false;
        }

    }

    public List<ContactDto>? GetContacts()
    {
        try
        {
            var json = _fileService.ReadContactFile();
            var contacts = JsonSerializer.Deserialize<List<ContactDto>>(json);

            return contacts;
        }
        catch
        {
            return [];
        }

    }


}
