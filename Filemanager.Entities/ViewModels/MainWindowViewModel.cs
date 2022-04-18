using Filemanager.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filemanager.Entities.ViewModels
{
    public class MainWindowViewModel
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

        public MainWindowViewModel()
        {
            _dataGridItems.Add(new()
            {
                Name = "test",
                Size = "50 kb",
                CreationTime = DateTime.Now.ToString(),
                UpdatedTime = DateTime.Now.ToString()
            });
        }
    }
}
