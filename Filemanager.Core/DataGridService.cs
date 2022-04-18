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

            _mainWindowView.Path = _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            GetDataGridItems();
        }

        public void SetPath(string path) => _path = path;

        public void GetDataGridItems()
        {
            DirectoryInfo directoryInfo = new(_path);

            foreach (var dir in directoryInfo.GetDirectories())
            {
                _mainWindowView.DataGridItems.Add(new()
                {
                    Name = dir.Name + '\\',
                    CreationTime = dir.CreationTime.ToString(),
                    UpdatedTime = dir.LastWriteTime.ToString()
                });
            }
            foreach (var file in directoryInfo.GetFiles())
            {
                _mainWindowView.DataGridItems.Add(new()
                {
                    Name = file.Name,
                    Size = file.Length.ToString(),
                    CreationTime = file.CreationTime.ToString(),
                    UpdatedTime = file.LastWriteTime.ToString()
                });
            }

        }
    }
}
