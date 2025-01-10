using Business.Interface;
using Business.Repositories;
using Data.Interfaces;
using Domain.Models;
using Moq;
using System.Text.Json;

namespace Business.Tests.Repositories;

/// <summary>
/// Performing test on ContactRepository (Mostly refrenced Course Videos, Some small adjustment with Chatgpt to fix kinks)
/// </summary>
public class ContactRepository_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactRepository _contactRepository;

    public ContactRepository_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactRepository = new ContactRepository(_fileServiceMock.Object);
    }


    [Fact]
    public void SaveContact_ShouldReturnTrue_WhenListOfContactEntitysIsConvertedToJsonAndSaved()
    {
        //Arrange
        var contactEntity = new ContactEntity()
        {
            Id = "1",
            FirstName = "John",
            LastName = "Smith",
            Email = "john.smith@domain.com",
            PhoneNumber = "1234567890",
            Adress = "Adress1",
            ZipCode = "702xx",
            County = "County"
        };
        var contactEntities = new List<ContactEntity> { contactEntity };

        // Chatgpt help
        var jsonSerialize = JsonSerializer.Serialize(contactEntities);

        _fileServiceMock.Setup(x => x.SaveContactToFile(It.IsAny<string>())).Returns(true);
        //Act
        var result = _contactRepository.SaveContacts(contactEntities);
        //Assert
        Assert.True(result);
        _fileServiceMock.Verify(x => x.SaveContactToFile(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void GetContacts_ShouldReturnListOfContactEntities()
    {
        //Arrange
        var contactEntity = new ContactEntity()
        {
            Id = "1",
            FirstName = "John",
            LastName = "Smith",
            Email = "john.smith@domain.com",
            PhoneNumber = "1234567890",
            Adress = "Adress1",
            ZipCode = "702xx",
            County = "County"
        };
        var contactEntities = new List<ContactEntity> { contactEntity };

        var jsonSerialize = JsonSerializer.Serialize(contactEntities);
        _fileServiceMock.Setup(x => x.ReadContactFile()).Returns(jsonSerialize);

        _contactRepository.SaveContacts(contactEntities);

        
        //Act
        var result = _contactRepository.GetContacts()!;

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);

        Assert.Equal(contactEntities[0].FirstName, result.First().FirstName);
        Assert.Equal(contactEntities[0].LastName, result.First().LastName);
        Assert.Equal(contactEntities[0].Email, result.First().Email);
        Assert.Equal(contactEntities[0].PhoneNumber, result.First().PhoneNumber);
        Assert.Equal(contactEntities[0].Adress, result.First().Adress);
        Assert.Equal(contactEntities[0].ZipCode, result.First().ZipCode);
        Assert.Equal(contactEntities[0].County, result.First().County);



    }
}
