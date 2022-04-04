using System.Windows.Input;

namespace WPFCommandFactory.Interfaces
{
    public interface ICommandFactory
    {
        public ICommand Create();
    }
}
