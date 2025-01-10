using Data.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace Data.Services;

public class FileService : IFileService
{



    private readonly string _directoryPath;
    private readonly string _filePath;


   
    public FileService(string directoryPath = "Data", string filePath = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(directoryPath, filePath);

    }

    public bool CreateDirectory()
    {
        try
        {
            // If directory don't exist 
            if (!Directory.Exists(_directoryPath))
            {
                // Create Directory
                Directory.CreateDirectory(_directoryPath);
            }
            return true;
        }
        catch(Exception ex) 
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool SaveContactToFile(string content)
    {
        try
        {
            CreateDirectory();
            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool CreateFile()
    {
        try
        {

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "Data");

            }

            return true;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public string ReadContactFile()
    {
        try
        {

            CreateFile();

            return File.ReadAllText(_filePath);
            
        }
        
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return "";
        }
    }
}