using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;

namespace Business.Tests.Factories;

public class ContactFactory_Tests
{
    private readonly IContactFactory _contactFactory = new ContactFactory();

 

    [Fact]
    public void CreateModel_ShouldRetrunNewModel()
    {
        //Arrange

        //Act
        var result = _contactFactory.CreateModel();
        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactModel>(result);
        
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
    

    public void CreateDto_ShouldReturnContactDto(string firstName, string lastName, string email, string phoneNumber, string adress, string zipCode, string county)
    {
        //Arrange
        ContactModel contactModel = new ContactModel() 
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
        var result = _contactFactory.CreateDto(contactModel);
        //Assert
        Assert.NotNull(result);
        Assert.IsType<ContactDto>(result);
        Assert.Equal(contactModel.FirstName, result.FirstName);
        Assert.Equal(contactModel.LastName, result.LastName);
        Assert.Equal(contactModel.Email, result.Email);
        Assert.Equal(contactModel.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contactModel.Adress, result.Adress);
        Assert.Equal(contactModel.ZipCode, result.ZipCode);
        Assert.Equal(contactModel.County, result.County);
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
        ContactDto contactDto = new ContactDto()
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
        var result = _contactFactory.CreateContact(contactDto);
        //Assert
        Assert.NotNull(result);
        Assert.IsType<Contact>(result);
        Assert.Equal(contactDto.Id, result.Id);
        Assert.Equal(contactDto.FirstName, result.FirstName);
        Assert.Equal(contactDto.LastName, result.LastName);
        Assert.Equal(contactDto.Email, result.Email);
        Assert.Equal(contactDto.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contactDto.Adress, result.Adress);
        Assert.Equal(contactDto.ZipCode, result.ZipCode);
        Assert.Equal(contactDto.County, result.County);
    }
}
