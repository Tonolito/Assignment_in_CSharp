using Business.Interface;
using Data.Interfaces;
using Data.Services;
using Domain.Models;
using System.Text.Json;

namespace Business.Repositories;

public class ContactRepository(IFileService fileService) : IContactRepository
{
    private readonly IFileService _fileService = fileService;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {

    };

    public bool SaveContacts(List<ContactEntity> contacts)
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

    public List<ContactEntity>? GetContacts()
    {
        try
        {
            var json = _fileService.ReadContactFile();
            var contacts = JsonSerializer.Deserialize<List<ContactEntity>>(json);

            return contacts;
        }
        catch
        {
            return [];
        }

    }


}
