// 代码生成时间: 2025-08-05 02:24:20
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Configuration manager class for handling configuration files.
/// </summary>
public class ConfigurationManager
{
    private readonly string _configFilePath;

    /// <summary>
    /// Initializes a new instance of ConfigurationManager with the specified configuration file path.
    /// </summary>
    /// <param name="configFilePath">The path to the configuration file.</param>
    public ConfigurationManager(string configFilePath)
    {
        _configFilePath = configFilePath ?? throw new ArgumentNullException(nameof(configFilePath));
    }

    /// <summary>
    /// Loads the configuration data from the file.
    /// </summary>
    /// <typeparam name="T">The type of the configuration data.</typeparam>
    /// <returns>The deserialized configuration data.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the configuration file is not found.</exception>
    /// <exception cref="JsonException">Thrown when the configuration data cannot be deserialized.</exception>
    public T LoadConfiguration<T>() where T : class, new()
    {
        if (!File.Exists(_configFilePath))
        {
            throw new FileNotFoundException("Configuration file not found.", _configFilePath);
        }

        string json = File.ReadAllText(_configFilePath);
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    /// <summary>
    /// Saves the configuration data to the file.
    /// </summary>
    /// <param name="configData">The configuration data to be saved.</param>
    /// <typeparam name="T">The type of the configuration data.</typeparam>
    /// <exception cref="ArgumentNullException">Thrown when the configData is null.</exception>
    /// <exception cref="JsonException">Thrown when the configuration data cannot be serialized.</exception>
    public void SaveConfiguration<T>(T configData) where T : class
    {
        if (configData == null)
        {
            throw new ArgumentNullException(nameof(configData));
        }

        string json = JsonSerializer.Serialize(configData, new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true });
        File.WriteAllText(_configFilePath, json);
    }
}
