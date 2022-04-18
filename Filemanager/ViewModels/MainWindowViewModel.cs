using Filemanager.Abstractions.Entities.Models;
using Filemanager.Abstractions.Interfaces.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace Filemanager
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private string _path = null!;
        private List<DataGridItemModel> _dataGridItems = new();

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

        public MainWindowViewModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string proprertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprertyName));
        }
    }
}
