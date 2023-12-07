namespace ClassLibrary.Shared.Interfaces;

internal interface IContact
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
    string Address { get; set; }
    string PostalCode { get; set; }
    string City { get; set; }
}
