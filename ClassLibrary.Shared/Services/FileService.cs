using ClassLibrary.Shared.Interfaces;
using System.Diagnostics;

namespace ClassLibrary.Shared.Services;

public class FileService(string filepath) : IFileService
{
    private readonly string _filepath = filepath;

    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filepath))
            {
                return File.ReadAllText(_filepath);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool RemoveContactFromFile(string contact)
    {
        try
        {
            string existingContent = GetContentFromFile();
            if (existingContent != null)
            {
                existingContent = existingContent.Replace(contact, string.Empty).Trim();

                File.WriteAllText(filepath, existingContent);

                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public bool SaveContactToFile(string contact)
    {
        try
        {
            using var sw = new StreamWriter(_filepath);
            sw.WriteLine(contact);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
