namespace Filemanager.Abstractions.Entities.Models
{
    public class DataGridItemModel
    {
        public string Name { get; set; } = null!;
        public string TypeItem { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string CreationTime { get; set; } = null!;
        public string UpdatedTime { get; set; } = null!;
    }
}
