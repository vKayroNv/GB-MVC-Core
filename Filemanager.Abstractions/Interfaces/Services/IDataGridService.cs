using Filemanager.Abstractions.Entities.Models;

namespace Filemanager.Abstractions.Interfaces.Services
{
    public interface IDataService
    {
        void SetPath(string path);

        List<DataGridItemModel> GetDataGridItems();
    }
}
