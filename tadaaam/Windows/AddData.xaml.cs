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
using System.Windows.Shapes;

namespace tadaaam.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddData.xaml
    /// </summary>
    public partial class AddData : Window
    {
        public ObservableCollection<Champion> _data = new ObservableCollection<Champion>();

        Guid Guid = Guid.NewGuid();
        public AddData()
        {
            InitializeComponent();
        }

        private void btn_saveData_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sFile = new SaveFileDialog();
            string json = JsonSerializer.Serialize<ObservableCollection<Champion>>(_data);

            sFile.Filter = "Json files (*.json)|*.json";

            sFile.ShowDialog();
            if (string.IsNullOrEmpty(sFile.FileName))
                return;
            File.WriteAllText(sFile.FileName, json);
        }

        private void btn_addData_Click(object sender, RoutedEventArgs e)
        {
            Champion champion = new Champion()
            { 
                Name = tb_name.Text,
                Class= tb_class.Text,
                Position = tb_position.Text
            };
            _data.Add(champion);
        }
    }
}
