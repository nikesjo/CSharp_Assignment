using ClassLibrary.Shared.Interfaces;
using ClassLibrary.Shared.Models;
using ClassLibrary.Shared.Services;
using Moq;
using Newtonsoft.Json;

namespace Addressbook.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactToList_ShouldAddContactToList_ThenReturnTrue()
    {
        //Arrange
        IContact contact = new Contact
        {
            FirstName = "FirstNameTest",
            LastName = "LastNameTest",
            PhoneNumber = "PhoneNumberTest",
            Email = "EmailTest",
            Address = "AddressTest",
            PostalCode = "PostalCodeTest",
            City = "CityTest"
        };

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.SaveContactToFile(It.IsAny<string>())).Returns(true);
        IContactService contactService = new ContactService(mockFileService.Object);

        //Act
        bool result = contactService.AddContactToList(contact);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void GetContactsFromList_ShouldGetAllContactsFromList_ThenReturnListOfContacts()
    {
        //Arrange
        var contacts = new List<IContact> { new Contact { FirstName = "FirstNameTest", LastName = "LastNameTest", PhoneNumber = "PhoneNumberTest", Email = "EmailTest", Address = "AddressTest", PostalCode = "PostalCodeTest", City = "CityTest" } };
        string json = JsonConvert.SerializeObject(contacts, Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContentFromFile()).Returns(json);
        IContactService contactService = new ContactService(mockFileService.Object);

        //Act
        IEnumerable<IContact> result = contactService.GetContactsFromList();

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
        IContact returned_contact = result.FirstOrDefault()!;
    }
}
