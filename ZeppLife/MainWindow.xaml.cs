using System;
using System.Collections.Generic;
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
using System.Text.Json;
using System.IO;

using OxyPlot;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace ZeppLife
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationUserViewModel();
        }

        private void LoadJson_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Json files|*.json|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            String badFiles = ""; 
            List<Data> monthData = new List<Data>();
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    
                    string jsonString = File.ReadAllText(fileName);
                    try
                    {
                        List<Data> dayData = JsonConvert.DeserializeObject<List<Data>>(jsonString);
                        foreach (var item in dayData)
                        {
                            item.Day = Int32.Parse(System.IO.Path.GetFileName(fileName).Split("day")[1].Split(".")[0]);
                        }
                        monthData.AddRange(dayData);
                    }
                    catch
                    {
                        badFiles += fileName + ";\n";
                        continue;
                    }
                } 
            }

            phonesGrid.ItemsSource = DataUtility.ModifyData(monthData); //ReadWriteJsonData.ReadData();
            phonesGrid.SelectedItem = phonesGrid.Items[0];
            SaveData.IsEnabled = true;
            if (badFiles != "")
                MessageBox.Show("Failed to load some of the files: \n" + badFiles);
        }

        private void phonesGrid_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {
            try
            {
                var tmp = (TableData)e.Row.DataContext;
                if (tmp.AverageSteps * 1.2 < tmp.MaxSteps)
                {
                    e.Row.Background = new SolidColorBrush(Colors.Green);
                }
                else if (tmp.AverageSteps * 0.8 > tmp.MinSteps)
                {
                    e.Row.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    e.Row.Background = new SolidColorBrush(Colors.WhiteSmoke);
                }
            }
            catch
            {
            }
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            if(phonesGrid.SelectedItem == null)
                MessageBox.Show("There is no selected item");
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Json files|*.json|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(phonesGrid.SelectedItem));
                    MessageBox.Show("Файл сохранён");
                }
            }
        }
    }
}
