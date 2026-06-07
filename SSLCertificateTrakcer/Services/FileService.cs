using SSLCertificateTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace SSLCertificateTracker.Services
{
    public class FileService
    {
        readonly string _folderPath = @"%APPDATA%\SSLCertTracker\";

        readonly JsonSerializerOptions _options;


        public FileService()
        {
            _options = new JsonSerializerOptions{ IncludeFields = true, PropertyNameCaseInsensitive = true, WriteIndented = true };
        }

        public async Task SaveAsync<T>(string filename, BindingList<CertificateModel> list)
        {
            try
            {

                string _expandedFilePath = Path.Combine(Environment.ExpandEnvironmentVariables(_folderPath), filename);

                string JsonString = JsonSerializer.Serialize(list, _options);

                await File.WriteAllTextAsync(_expandedFilePath, JsonString);

                Debug.WriteLine($"JSON File Created/Updated in directory\nFile Path: {_expandedFilePath}");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
