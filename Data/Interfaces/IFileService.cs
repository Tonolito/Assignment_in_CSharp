namespace Data.Interfaces
{
    public interface IFileService
    {
        string ReadContactFile();
        bool SaveContactToFile(string content);
    }
}