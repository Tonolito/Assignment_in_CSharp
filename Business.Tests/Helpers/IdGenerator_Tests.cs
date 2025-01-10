using Business.Helpers;

namespace Business.Tests.Helpers;

public class IdGenerator_Tests
{

    
    [Fact]
    public void NewId_ShouldReturnStringOfTypeGuid()
    {
        //Arrange
        IdGenerator idGenerator = new IdGenerator();
        //Act
        var result = idGenerator.NewId();
        //Assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));


    }

}
