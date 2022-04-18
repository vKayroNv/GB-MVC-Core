using Filemanager.Abstractions.Entities.Models;
using Filemanager.Abstractions.Interfaces.Services;
using Filemanager.Abstractions.Interfaces.ViewModels;

namespace Filemanager.Core
{
    public class DataService : IDataService
    {
        private readonly IMainWindowViewModel _mainWindowView = null!;

        private string _path = null!;

        public DataService(IMainWindowViewModel mainWindowView)
        {
            _mainWindowView = mainWindowView;

            Task.Factory.StartNew(() =>
            {
                _mainWindowView.Path = _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                GetDataGridItems();

                Thread.Sleep(5000);

                _mainWindowView.Path = _path = "\\\\";
                GetDataGridItems();
            });

        }

        public void SetPath(string path) => _path = path;

        public void GetDataGridItems()
        {
            if (_path == "\\\\")
                GetDrivesEntries();
            else
                GetDirectoryEntries();
        }

        private void GetDirectoryEntries()
        {
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

            _mainWindowView.DataGridItems = result;
        }

        private void GetDrivesEntries()
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

            _mainWindowView.DataGridItems = result;
        }
    }
}
