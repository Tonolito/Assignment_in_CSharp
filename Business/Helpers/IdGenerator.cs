using Business.Interface;

namespace Business.Helpers;

public class IdGenerator : IIdGenerator
{
    
    
    public  string NewId()
    {
        {
            return Guid.NewGuid().ToString();
        }
    }
}
