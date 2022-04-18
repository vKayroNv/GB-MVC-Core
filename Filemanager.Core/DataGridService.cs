using Filemanager.Abstractions.Entities.Models;
using Filemanager.Abstractions.Interfaces.Services;

namespace Filemanager.Core
{
    public class DataService : IDataService
    {
        private string _path = null!;

        public void SetPath(string path) => _path = path;

        public List<DataGridItemModel> GetDataGridItems()
        {
            if (_path == "\\\\")
            {
                return GetDrivesEntries();
            }
            else
            {
                return GetDirectoryEntries();
            }
        }

        private List<DataGridItemModel> GetDirectoryEntries()
        {
            if (!Directory.Exists(_path))
            {
                return null!;
            }

            var result = new List<DataGridItemModel>();

            DirectoryInfo directoryInfo = new(_path);

            foreach (var dir in directoryInfo.GetDirectories())
            {
                result.Add(new()
                {
                    Name = dir.Name + '\\',
                    TypeItem = "Папка",
                    CreationTime = dir.CreationTime.ToString(),
                    UpdatedTime = dir.LastWriteTime.ToString()
                });
            }
            foreach (var file in directoryInfo.GetFiles())
            {
                result.Add(new()
                {
                    Name = file.Name,
                    TypeItem = "Файл",
                    Size = file.Length.ToString(),
                    CreationTime = file.CreationTime.ToString(),
                    UpdatedTime = file.LastWriteTime.ToString()
                });
            }

            return result;
        }

        private List<DataGridItemModel> GetDrivesEntries()
        {
            var result = new List<DataGridItemModel>();

            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                result.Add(new()
                {
                    Name = drive.Name,
                    TypeItem = "Диск"
                });
            }

            return result;
        }
    }
}
