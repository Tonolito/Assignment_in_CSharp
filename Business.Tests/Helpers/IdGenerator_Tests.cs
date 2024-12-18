using Business.Helpers;

namespace Business.Tests.Helpers;

public class IdGenerator_Tests
{
    [Fact]
    public void NewId_ShouldReturnStringOfTypeGuid()
    {
        // Arrange

        // Act
        string id = IdGenerator.NewId();
        // Assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
        
    }

}
