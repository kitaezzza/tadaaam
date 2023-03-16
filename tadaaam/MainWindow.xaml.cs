using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using tadaaam.Windows;

namespace tadaaam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Champion> _data = new ObservableCollection<Champion>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            Champion del = ((Champion)d_grid.SelectedItem);
            d_grid.Items.Remove(del);
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddData add = new AddData();
            add.Show();
        }

        private void btn_openDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "Json files (*.json)|*.json";
            oFile.ShowDialog();
            if (string.IsNullOrEmpty(oFile.FileName))
            {
                return;
            }
            string json = File.ReadAllText(oFile.FileName);

            try
            {
                _data = JsonSerializer.Deserialize<ObservableCollection<Champion>>(json);
                foreach (Champion champ in _data)
                {
                    d_grid.Items.Add(champ);
                }
            }
            catch (System.Text.Json.JsonException)
            {
                MessageBox.Show("В данном файле отсутствуют компоненты нужного формата");
            }
        }
    }
}
