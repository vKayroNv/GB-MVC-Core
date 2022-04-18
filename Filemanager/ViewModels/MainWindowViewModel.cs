using Filemanager.Abstractions.Entities.Models;
using Filemanager.Abstractions.Interfaces.Services;
using Filemanager.Abstractions.Interfaces.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace Filemanager
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private readonly IDataService _dataService = null!;

        public MainWindowViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }



        private string _path = null!;
        private List<DataGridItemModel> _dataGridItems = new();
        private RelayCommand _changePathFromUICommand = null!;

        public List<DataGridItemModel> DataGridItems
        {
            get => _dataGridItems;
            set
            {
                _dataGridItems = value;
                OnPropertyChanged("DataGridItems");
            }
        }
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }
        public RelayCommand ChangePathFromUICommand
        {
            get
            {
                return _changePathFromUICommand ??= new RelayCommand(obj =>
                {
                    _dataService.SetPath(_path);
                    DataGridItems = _dataService.GetDataGridItems();
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string proprertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprertyName));
        }
    }
}
