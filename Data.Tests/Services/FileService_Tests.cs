using Data.Interfaces;
using Data.Services;
using System.Diagnostics;

namespace Domain.Tests.Services;

public class FileService_Tests
{
  
  

    [Fact]
    public void CreateDirectory_ShouldCreateDirectory()
    {
        //Arrange
        FileService fileService = new FileService();

        //Act
        var result = fileService.CreateDirectory();

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void CreateFile_ShouldCreateFile()
    {

        //Arrange
        FileService fileService = new FileService();

        //Act
        var result = fileService.CreateFile();

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void SaveContactToFile_ShouldReturnTrue_WhenSavingContactSucceeds()
    {
        //Arrange
        var content = "test";

        var fileName = $"{Guid.NewGuid().ToString()}.json";

        IFileService fileService = new FileService("Test.json");

        try
        {
            //Act
            var result = fileService.SaveContactToFile(content);
            //Assert
            Assert.True(result);
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }


    }

    [Fact]
    public void ReadContactFile_ShouldReturnJsonFile()
    {
        //Arrange
        FileService fileService = new FileService();

        var fileName = $"{Guid.NewGuid().ToString()}.json";


        var expected = "Some Data";

        //Act
        var result = fileService.ReadContactFile();

        //Assert
        Assert.Equal(result, expected);
    }

   
   
}
