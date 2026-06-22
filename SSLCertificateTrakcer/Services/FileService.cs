using SSLCertificateTracker.Model;
using SSLCertificateTracker.Subclass;
using System.Diagnostics;
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

        public async Task SaveAsync(SortableBindingList<CertificateModel> list)
        {
            string _expandedFolderPath = Environment.ExpandEnvironmentVariables(_folderPath);
            if(list.Count <= 0) return;
            try
            {
                if (!Directory.Exists(Environment.ExpandEnvironmentVariables(_expandedFolderPath)))
                {
                    Directory.CreateDirectory(_expandedFolderPath);
                }

                string _expandedFilePath = Path.Combine(_expandedFolderPath, "sites.json");

                string JsonString = JsonSerializer.Serialize(list, _options);

                await File.WriteAllTextAsync(_expandedFilePath, JsonString);

                Debug.WriteLine($"JSON File Created/Updated in directory\nFile Path: {_expandedFilePath}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SortableBindingList<CertificateModel>> GetAllAsync()
        {
            string _expandedFolderPath = Environment.ExpandEnvironmentVariables(_folderPath);
            string _expandedFilePath = Path.Combine(_expandedFolderPath, "sites.json");
            try
            {
                if (!Directory.Exists(_expandedFolderPath))
                {
                    Directory.CreateDirectory(_expandedFolderPath);
                    Debug.WriteLine($"Application folder not found in directory.\nNew Folder Path created for application data:\nFile Path: {_expandedFolderPath}");
                }

                //Binding Data to the Grid before form is created.
                if (File.Exists(_expandedFilePath))
                {
                    using Stream ExistingJson = File.OpenRead(_expandedFilePath);
                    Debug.WriteLine($"Certificate Data Parsed From JSON.\nFile Path: {_expandedFilePath}");
                    return await JsonSerializer.DeserializeAsync<SortableBindingList<CertificateModel>>(ExistingJson, _options);
                }
                else
                {
                    Debug.WriteLine("No File Found - New list made");
                    return new SortableBindingList<CertificateModel>();
                }
            }
            catch (JsonException) 
            {
                MessageBox.Show("The data in JSON may be malformed or corrupted.\nA new list was created.","File Unreadable!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(_expandedFilePath);
                return new SortableBindingList<CertificateModel>();
            }
        }

    }
}
