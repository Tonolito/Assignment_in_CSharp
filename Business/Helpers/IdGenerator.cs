namespace Business.Helpers;

public class IdGenerator
{

    public static string NewId()
    {
        {
            return Guid.NewGuid().ToString();
        }
    }
}
