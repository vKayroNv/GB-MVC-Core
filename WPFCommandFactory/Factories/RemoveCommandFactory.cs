using System.Windows.Controls;
using System.Windows.Input;
using WPFCommandFactory.Interfaces;
using WPFCommandFactory.Models;

namespace WPFCommandFactory.Factories
{
    public class RemoveCommandFactory : ICommandFactory
    {
        private readonly ListBox _listBox;

        public RemoveCommandFactory(ListBox listBox)
        {
            _listBox = listBox;
        }

        public ICommand Create()
        {
            return new Command(o => RemoveCommand());
        }

        private void RemoveCommand()
        {
            var person = _listBox.SelectedItem as Person;

            if (person != null)
            {
                _listBox.Items.Remove(person);
            }
        }
    }
}
