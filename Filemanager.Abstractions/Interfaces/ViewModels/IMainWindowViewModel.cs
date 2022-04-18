using Filemanager.Abstractions.Entities.Models;

namespace Filemanager.Abstractions.Interfaces.ViewModels
{
    public interface IMainWindowViewModel
    {
        public List<DataGridItemModel> DataGridItems { get; set; }
        public string Path { get; set; }
    }
}
