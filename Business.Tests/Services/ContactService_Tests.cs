using Business.Interface;
using Business.Services;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace Business.Tests.Services;

public class ContactService_Tests
{
   
   
    private readonly Mock<IContactFactory> _contactFactoryMock;
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly Mock<IIdGenerator> _idGeneratorMock;
    private readonly IContactService _contactService;
    public ContactService_Tests()
    {
        
        _contactFactoryMock = new Mock<IContactFactory>();
        _contactRepositoryMock = new Mock<IContactRepository>();
        _idGeneratorMock = new Mock<IIdGenerator>();
        _contactService = new ContactService(_contactFactoryMock.Object, _contactRepositoryMock.Object, _idGeneratorMock.Object);
    }

    [Fact]
    public void AddContact_ShouldReturnTrue_WhenContactIsAdded()
    {
        // Arrange
        var contactEntity = new ContactEntity
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

        var contactDto = new ContactDto
        {
            
            FirstName = "John",
            LastName = "Smith",
            Email = "john.smith@domain.com",
            PhoneNumber = "1234567890",
            Adress = "Adress1",
            ZipCode = "702xx",
            County = "County"
        };

        var contactEntities = new List<ContactEntity> { contactEntity };

        _idGeneratorMock.Setup(x => x.NewId()).Returns("1");
        
        _contactFactoryMock.Setup(y => y.CreateEntity(contactDto)).Returns(contactEntity);

        _contactRepositoryMock.Setup(z => z.SaveContacts(contactEntities)).Returns(true);

        // Act
        var result = _contactService.AddContact(contactDto);

        // Assert 
        Assert.True(result);
        
    }


    [Fact]
    public void GetContacts_ShouldReturnListOfContacts_WhenListExist()
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

        var contact = new Contact()
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


        _contactRepositoryMock.Setup(x => x.GetContacts()).Returns(contactEntities);

        _contactFactoryMock.Setup(y => y.CreateContact(contactEntity)).Returns(contact);

        //Act
        var result = _contactService.GetContacts();

        //Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(contact.Id, result.First().Id);
        Assert.Equal(contact.FirstName, result.First().FirstName);
        Assert.Equal(contact.LastName, result.First().LastName);
        Assert.Equal(contact.Email, result.First().Email);
        Assert.Equal(contact.PhoneNumber, result.First().PhoneNumber);
        Assert.Equal(contact.Adress, result.First().Adress);
        Assert.Equal(contact.ZipCode, result.First().ZipCode);
        Assert.Equal(contact.County, result.First().County);
    }

    [Fact]
    public void UpdateContact_ShouldReturnTrue_WhenIsUpdated()
    {
        // Arrange
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

        var updatedContact = new Contact()
        {
            Id = "1",
            FirstName = "Updated",
            LastName = "Updated",
            Email = "Updated@domain.com",
            PhoneNumber = "Updated",
            Adress = "Updated",
            ZipCode = "Updated",
            County = "Updated"
        };

        _contactRepositoryMock.Setup(x => x.GetContacts()).Returns(contactEntities);

        _contactRepositoryMock.Setup(x => x.SaveContacts(contactEntities)).Returns(true);

        // Hjälp av Chatgpt (För vi måste ha en lista med contacter i för att kunna undersöka)
        _contactService.GetContacts();
        // Act
        var result = _contactService.UpdateContact(updatedContact);
        //Assert
        Assert.True(result);
        Assert.Equal("1", contactEntity.Id);
        Assert.Equal("Updated", contactEntity.FirstName);
        Assert.Equal("Updated", contactEntity.LastName);
        Assert.Equal("Updated@domain.com", contactEntity.Email);
        Assert.Equal("Updated", contactEntity.PhoneNumber);
        Assert.Equal("Updated", contactEntity.Adress);
        Assert.Equal("Updated", contactEntity.ZipCode);
        Assert.Equal("Updated", contactEntity.County);
    }

    [Fact]
    public void DeleteContact_ShouldReturnTrue_WhenContactIsDeleted()
    {
        // Arrange
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

        var contact = new Contact()
        {
            Id = "1",
            FirstName = "Updated",
            LastName = "Updated",
            Email = "Updated@domain.com",
            PhoneNumber = "Updated",
            Adress = "Updated",
            ZipCode = "Updated",
            County = "Updated"
        };

        _contactRepositoryMock.Setup(x => x.GetContacts()).Returns(contactEntities);

        _contactRepositoryMock.Setup(x => x.SaveContacts(contactEntities)).Returns(true);

        _contactService.GetContacts();

        // Act

       var result = _contactService.DeleteContact(contact);

        //Assert
        Assert.True(result);
        
    }
}
