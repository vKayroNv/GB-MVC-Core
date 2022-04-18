using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filemanager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":
                    e.Column.Header = "Имя";
                    e.Column.Width = new DataGridLength(180);
                    break;

                case "TypeItem":
                    e.Column.Header = "Тип";
                    e.Column.Width = new DataGridLength(50);
                    break;

                case "Size":
                    e.Column.Header = "Размер";
                    e.Column.Width = new DataGridLength(70);
                    break;

                case "CreationTime":
                    e.Column.Header = "Дата создания";
                    e.Column.Width = new DataGridLength(120);
                    break;

                case "UpdatedTime":
                    e.Column.Header = "Дата обновления";
                    e.Column.Width = new DataGridLength(120);
                    break;

                default:
                    break;
            }
        }
    }
}
