using System;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCommandFactory.Interfaces;
using WPFCommandFactory.Models;

namespace WPFCommandFactory.Factories
{
    public class AddCommandFactory : ICommandFactory
    {
        private readonly ListBox _listBox;
        private readonly TextBox _surname, _firstname, _age;

        public AddCommandFactory(ListBox listBox, TextBox surname, TextBox firstname, TextBox age)
        {
            _listBox = listBox;
            _surname = surname;
            _firstname = firstname;
            _age = age;
        }

        public ICommand Create()
        {
            return new Command(o => AddCommand());
        }

        private void AddCommand()
        {
            var person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = _firstname.Text,
                SurName = _surname.Text,
                Age = int.Parse(_age.Text)
            };

            _listBox.Items.Add(person);
        }
    }
}
