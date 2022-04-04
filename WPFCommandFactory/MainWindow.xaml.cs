using System.Windows;
using System.Windows.Controls;
using WPFCommandFactory.Factories;
using WPFCommandFactory.Interfaces;
using WPFCommandFactory.Models;

namespace WPFCommandFactory
{
    public partial class MainWindow : Window
    {
        private readonly ICommandFactory commandFactory1, commandFactory2;

        public MainWindow()
        {
            InitializeComponent();

            commandFactory1 = new AddCommandFactory(fioList, surname, firstname, age);
            commandFactory2 = new RemoveCommandFactory(fioList);

            addPerson.Command = commandFactory1.Create();
            removePerson.Command = commandFactory2.Create();
        }

        private void fioList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fioList.SelectedIndex == -1)
            {
                surnameLabel.Content = string.Empty;
                firstnameLabel.Content = string.Empty;
                ageLabel.Content = string.Empty;
                return;
            }

            var person = fioList.SelectedItem as Person;

            if (person != null)
            {
                surnameLabel.Content = person.SurName;
                firstnameLabel.Content = person.FirstName;
                ageLabel.Content = person.Age;
            }
        }
    }
}
