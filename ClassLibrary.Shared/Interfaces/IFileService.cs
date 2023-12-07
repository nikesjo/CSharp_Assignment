﻿namespace ClassLibrary.Shared.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Save contact to a filepath.
    /// </summary>
    /// <param name="filepath">Enter the filepath with extension (eg. d:\Education\csharp\assignment\myfile.json)</param>
    /// <param name="contact">Enter the contact as a string.</param>
    /// <returns>Returns true if saved, or false if failed.</returns>
    bool SaveContactToFile(string filepath, string contact);

    /// <summary>
    /// Get content as string from a filepath.
    /// </summary>
    /// <param name="filepath">Enter the filepath with extension (eg. d:\Education\csharp\assignment\myfile.json)</param>
    /// <returns>Returns file content as string if file exists, or returns null.</returns>
    string GetContentFromFile(string filepath);
}
