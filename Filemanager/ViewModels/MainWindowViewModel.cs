using System.ComponentModel;

namespace Filemanager
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string proprertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprertyName));
        }
    }
}
