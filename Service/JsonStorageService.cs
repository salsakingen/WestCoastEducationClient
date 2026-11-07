using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using WestCoastEducationClient.InterFace;

namespace WestCoastEducationClient.Service;

public class JsonStorageService<T> : IHttpService<T> where T : class
{
    // Relative path: resolves against the folder the app runs from.
    // ("/Data/" would point at the root of the drive.)
    private readonly string basePath = "Data";

    private static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    // Data/<resource>/  – created if it doesn't exist
    private string GetFolder(string resource)
    {
        var folder = Path.Combine(basePath, resource);
        Directory.CreateDirectory(folder);
        return folder;
    }

    // Data/<resource>/<id>.json
    private string GetFilePath(string resource, string id)
    {
        return Path.Combine(GetFolder(resource), $"{id}.json");
    }

    // Reads the object's "Id" property. If it's an empty string, a new Guid is assigned.
    private static string GetOrCreateId(T data)
    {
        var prop = typeof(T).GetProperty("Id",
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

        if (prop == null)
            throw new InvalidOperationException($"{typeof(T).Name} needs an Id property to be stored.");

        var value = prop.GetValue(data)?.ToString();

        if (string.IsNullOrWhiteSpace(value) && prop.PropertyType == typeof(string) && prop.CanWrite)
        {
            value = Guid.NewGuid().ToString();
            prop.SetValue(data, value);
        }

        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException($"{typeof(T).Name} has no Id value.");

        return value;
    }

    public Task Delete(string resource, string id)
    {
        var file = GetFilePath(resource, id);
        if (File.Exists(file))
            File.Delete(file);

        return Task.CompletedTask;
    }

    public async Task<List<T>> Get(string resource)
    {
        var result = new List<T>();

        foreach (var file in Directory.GetFiles(GetFolder(resource), "*.json"))
        {
            var json = await File.ReadAllTextAsync(file);
            var item = JsonSerializer.Deserialize<T>(json, options);
            if (item != null)
                result.Add(item);
        }

        return result;
    }

    // predicate = the object's id
    public async Task<T> Get(string resource, string predicate)
    {
        var file = GetFilePath(resource, predicate);
        if (!File.Exists(file))
            throw new KeyNotFoundException($"No {resource} with id '{predicate}' was found.");

        var json = await File.ReadAllTextAsync(file);
        return JsonSerializer.Deserialize<T>(json, options);
    }

    public async Task Post(string resource, T data)
    {
        var id = GetOrCreateId(data);
        var file = GetFilePath(resource, id);

        if (File.Exists(file))
            throw new InvalidOperationException($"A {resource} with id '{id}' already exists.");

        await File.WriteAllTextAsync(file, JsonSerializer.Serialize(data, options));
    }

    public async Task Put(string resource, T data, string objectId)
    {
        var file = GetFilePath(resource, objectId);

        if (!File.Exists(file))
            throw new KeyNotFoundException($"No {resource} with id '{objectId}' was found.");

        await File.WriteAllTextAsync(file, JsonSerializer.Serialize(data, options));
    }
}