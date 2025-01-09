using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;

namespace Business.Tests.Factories;

public class ContactFactory_Tests
{
    private readonly IContactFactory _contactFactory = new ContactFactory();

 

    [Fact]
    public void CreateDto_ShouldRetrunNewModel()
    {
        //Arrange

        //Act
        var result = _contactFactory.CreateDto();
        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactDto>(result);
        
    }



    [Theory]
    [InlineData("FirstName",
        "LastName",
        "Firstname.lastname@domain.com",
        "070xxx0011",
        "Adress 1",
        "702 00",
        "County")]
    [InlineData
        (
        "",
        "",
        "",
        "",
        "",
        "",
        ""
        )]
   
    public void CreateEntity_ShouldReturnContactDto(string firstName, string lastName, string email, string phoneNumber, string adress, string zipCode, string county)
    {
        //Arrange
        ContactDto contactDto = new Domain.Dtos.ContactDto() 
        { 
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Adress = adress,
            ZipCode = zipCode,
            County = county,
        };
        //Act
        var result = _contactFactory.CreateEntity(contactDto);
        //Assert
        Assert.NotNull(result);
        Assert.IsType<ContactEntity>(result);
        Assert.Equal(contactDto.FirstName, result.FirstName);
        Assert.Equal(contactDto.LastName, result.LastName);
        Assert.Equal(contactDto.Email, result.Email);
        Assert.Equal(contactDto.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contactDto.Adress, result.Adress);
        Assert.Equal(contactDto.ZipCode, result.ZipCode);
        Assert.Equal(contactDto.County, result.County);
    }


    [Theory]
    [InlineData
        (
        "Id",
        "FirstName",
        "LastName",
        "Firstname.lastname@domain.com",
        "070xxx0011",
        "Adress 1",
        "702 00",
        "County"
        )]
    public void CreateContact_ShouldReturnContact(string id, string firstName, string lastName, string email, string phoneNumber, string adress, string zipCode, string county)
    {
        //Arrange
        ContactEntity contactEntity = new Domain.Models.ContactEntity()
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Adress = adress,
            ZipCode = zipCode,
            County = county
        };
        //Act
        var result = _contactFactory.CreateContact(contactEntity);
        //Assert
        Assert.NotNull(result);
        Assert.IsType<Contact>(result);
        Assert.Equal(contactEntity.Id, result.Id);
        Assert.Equal(contactEntity.FirstName, result.FirstName);
        Assert.Equal(contactEntity.LastName, result.LastName);
        Assert.Equal(contactEntity.Email, result.Email);
        Assert.Equal(contactEntity.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contactEntity.Adress, result.Adress);
        Assert.Equal(contactEntity.ZipCode, result.ZipCode);
        Assert.Equal(contactEntity.County, result.County);
    }
}
