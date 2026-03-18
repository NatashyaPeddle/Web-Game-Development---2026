using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataService : IDataService
{
    private ISerializer serializer;  // Serializer field
    private string datapath;  // Path where the save file is located
    private string fileExtension;  // Extension for save files

    // Constructor where the serializer is passed in and assigned to the field
    public FileDataService(ISerializer serializer)
    {
        this.serializer = serializer;  // Properly initialize the serializer field
        datapath = Application.persistentDataPath;  // Default save location
        fileExtension = ".json";  // Default file extension
    }

    // Method to generate the full file path based on the file name
    private string GetPathFile(string fileName)
    {
        return Path.Combine(datapath, string.Concat(fileName, fileExtension));
    }

    // Save method to serialize the data and write it to a file
    public void Save(GameData data, bool overwrite = true)
    {
        if (data == null)
        {
            Debug.LogError("Cannot save: GameData is null.");
            return;
        }

        string fileLocation = GetPathFile(data.fileName);

        // Check if the file exists and whether overwriting is allowed
        if (!overwrite && File.Exists(fileLocation))
        {
            throw new IOException("File already exists and cannot be overwritten.");
        }

        try
        {
            // Serialize the data and write it to the file
            File.WriteAllText(fileLocation, serializer.Serialize(data));
            Debug.Log($"Game data saved to: {fileLocation}");
        }
        catch (IOException ex)
        {
            Debug.LogError($"Error saving file: {ex.Message}");
        }
    }

    // Load method to read the file and deserialize it into GameData
    public GameData Load(string fileName)
    {
        string fileLocation = GetPathFile(fileName);

        if (!File.Exists(fileLocation))
        {
            throw new System.Exception($"No persistent data found at: {fileLocation}");
        }

        try
        {
            string json = File.ReadAllText(fileLocation);
            return serializer.Deserialize<GameData>(json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error loading file: {ex.Message}");
            return null;
        }
    }

    // Delete method to remove the file from the storage
    public void Delete(string fileName)
    {
        string fileLocation = GetPathFile(fileName);

        if (File.Exists(fileLocation))
        {
            try
            {
                File.Delete(fileLocation);
                Debug.Log($"Deleted save file: {fileLocation}");
            }
            catch (IOException ex)
            {
                Debug.LogError($"Error deleting file: {ex.Message}");
            }
        }
        else
        {
            Debug.LogError($"File not found: {fileLocation}");
        }
    }

    // Method to list all save files in the directory
    public IEnumerable<string> ListSaves()
    {
        foreach (string path in Directory.EnumerateFiles(datapath))
        {
            if (Path.GetExtension(path) == fileExtension)
            {
                yield return Path.GetFileNameWithoutExtension(path);  // Return file name without extension
            }
        }
    }
}
