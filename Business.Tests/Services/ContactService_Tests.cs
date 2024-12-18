using Business.Services;
using Domain.Dtos;
using Domain.Factories;

namespace Business.Tests.Services;

public class ContactService_Tests
{
    private readonly ContactService _contactService = new();

   public void  AddContact_ShouldReturn()
    {

    }


    [Fact]
    public void GetContacts_ShouldReturnListOfContacts_WhenListExist()
    {
        //Arrange
        var contact = new ContactDto { FirstName = "Contact", LastName = "Test", Email = "Test@domain.com" };
        ContactFactory contactFactory = new ContactFactory();
        
        //Act


        //Assert

    }
}
