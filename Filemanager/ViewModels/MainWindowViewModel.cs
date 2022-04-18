using Filemanager.Abstractions.Entities.Models;
using Filemanager.Abstractions.Interfaces.ViewModels;
using System.Collections.Generic;

namespace Filemanager
{ 
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private string _path = null!;
        private List<DataGridItemModel> _dataGridItems = new();

        public List<DataGridItemModel> DataGridItems
        {
            get => _dataGridItems;
            set => _dataGridItems = value;
        }
        public string Path 
        { 
            get => _path; 
            set => _path = value; 
        }
    }
}
