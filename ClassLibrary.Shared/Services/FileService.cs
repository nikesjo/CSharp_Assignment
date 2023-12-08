using ClassLibrary.Shared.Interfaces;
using System.Diagnostics;

namespace ClassLibrary.Shared.Services;

public class FileService : IFileService
{
    public string GetContentFromFile(string filepath)
    {
        try
        {
            if (File.Exists(filepath))
            {
                return File.ReadAllText(filepath);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool SaveContactToFile(string filepath, string contact)
    {
        try
        {
            using var sw = new StreamWriter(filepath);
            sw.WriteLine(contact);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
