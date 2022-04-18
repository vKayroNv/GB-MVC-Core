using Filemanager.Abstractions.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filemanager.Abstractions.Interfaces.ViewModels
{
    public interface IMainWindowViewModel
    {
        public List<DataGridItemModel> DataGridItems { get; set; }
        public string Path { get; set; }
    }
}
