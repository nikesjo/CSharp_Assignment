﻿using ClassLibrary.Shared.Interfaces;
using Newtonsoft.Json;
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
                using var sr = new StreamReader(_filepath);
                return sr.ReadToEnd();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
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

    public bool UpdateContactListToFile(List<IContact> contact)
    {
        try
        {
            var serializedContacts = JsonConvert.SerializeObject(contact, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented });
            using var sw = new StreamWriter(_filepath);
            sw.WriteLine(serializedContacts);

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}