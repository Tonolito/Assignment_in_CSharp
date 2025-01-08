namespace Domain.Interfaces
{
    public interface IContactDto
    {
        string Adress { get; set; }
        string County { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string ZipCode { get; set; }
    }
}