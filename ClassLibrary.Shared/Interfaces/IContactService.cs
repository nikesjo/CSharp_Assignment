﻿namespace ClassLibrary.Shared.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Add a contact to the contact list.
    /// </summary>
    /// <param name="contact">A contact of type IContact</param>
    /// <returns>Return true if successful, or false if it fails or customer already exists.</returns>
    bool AddContactToList(IContact contact);

    /// <summary>
    /// Gets all contacts from contact list.
    /// </summary>
    /// <returns>Return contacts if list has contacts in it, if no contacts exists return null.</returns>
    IEnumerable<IContact> GetContactsFromList();

    /// <summary>
    /// Get a specific contact from contact list by email.
    /// </summary>
    /// <param name="email">Enter the email as a string.</param>
    /// <returns>Return contact if exists, if contact does not exists return null.</returns>
    IContact GetContactFromList(string email);

    /// <summary>
    /// Updates existing contact in list.
    /// </summary>
    /// <param name="contact">A contact of type IContact</param>
    void UpdateContact(IContact contact);

    /// <summary>
    /// Removes a contact from the contact list by email.
    /// </summary>
    /// <param name="email">Enter the email as a string.</param>
    /// <returns>Return true if the contact was successfully removed, or false if otherwise.</returns>
    bool RemoveContactFromList(string email);

    event EventHandler ContactsUpdated;
}
