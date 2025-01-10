using Data.Interfaces;
using Data.Services;
using System.Diagnostics;

namespace Domain.Tests.Services;

public class FileService_Tests
{

    private readonly string _filePath = $"{Guid.NewGuid().ToString()}.json";

    private readonly string _directoryPath = "Testdata";
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

        var _filePath = $"{Guid.NewGuid().ToString()}.json";

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
            if (File.Exists(_filePath))
                File.Delete(_filePath);
        }


    }
    /// <summary>
    /// Arrange writes the file and save the "content" to the file, then we try to read it. In Assert we check if the content is equal
    /// </summary>
    [Fact]
    public void ReadContactFile_ShouldReturnFile()
    {
        //Arrange
        
        var _filePath = $"{Guid.NewGuid().ToString()}.json";
        
        var content = "Some Data";

        File.WriteAllText(_filePath, content);

        IFileService fileService = new FileService(_directoryPath, _filePath);
        fileService.SaveContactToFile(content);

        try
        {
            //Act
            var result = fileService.ReadContactFile();

            //Assert
            Assert.Equal(result, content);
        }
        finally
        {       // Hjälp av Chatgpt (Om directory finns så lista alla filer och ta bort readonly osv. Sedan ta bort Directotory
            if (Directory.Exists(_directoryPath))
            {
                foreach (var file in Directory.GetFiles(_directoryPath))
                {
                    File.SetAttributes(file, FileAttributes.Normal); // Remove readonly/hidden attributes
                    File.Delete(file);
                }

           
                Directory.Delete(_directoryPath);
            }
        }
       
    }

   
   
}
