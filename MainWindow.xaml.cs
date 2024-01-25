using Felveteli;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Felveteli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Felvetelizo> diakok = new();
        ObservableCollection<IFelvetelizo> sorok = new ObservableCollection<IFelvetelizo>();
        public MainWindow()
        {
            InitializeComponent();
            dg_diakok.ItemsSource = sorok;
        }

        private void LoadData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);


            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");
                diakok.Add(new Felvetelizo(line[0], line[1], line[2], DateTime.Parse(line[3]), line[4], Convert.ToInt16(line[5]), Convert.ToInt16(line[6])));
            }
            sr.Close();
            dg_diakok.ItemsSource = diakok;
        }

        private void SaveData(string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);

            foreach (var diak in diakok)
            {
                sw.WriteLine($"{diak.Az};{diak.Neve};{diak.ErtCím};{diak.SzülDatum};{diak.Email};{diak.MatekPontok};{diak.MagyarPontok};");
            }
            sw.Close();
        }

        private void btn_import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            if (fileName != "")
            {
                LoadData(fileName);
            }
        }

        private void btn_export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();

            string fileName = saveFileDialog.FileName;
            if (fileName != "")
            {
                SaveData(fileName);
            }
        }

        private void btn_torol_Click(object sender, RoutedEventArgs e)
        {
            if (dg_diakok.SelectedIndex != -1)
            {
                diakok.Remove(diakok[dg_diakok.SelectedIndex]);
                dg_diakok.Items.Refresh();
                dg_diakok.ItemsSource = diakok;
            }
        }

       


        private void btn_ujdiak_Click(object sender, RoutedEventArgs e)
        {
            Felvetelizo ujdiak = new Felvetelizo();
            ujdiak.Neve = txtAdat.Text;

            WinUjfelvetelizo ujablak = new WinUjfelvetelizo(ujdiak);
            ujablak.ShowDialog();

            lbCSVsor.Content = ujdiak.CSVSortAdVissza();
            diakok.Add(ujdiak);
        }
        
        private void btn_modosit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
