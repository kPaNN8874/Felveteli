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

namespace Felveteli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WinUjfelvetelizo : Window
    {
        Felvetelizo felvetelizoAdatai;
        public WinUjfelvetelizo()
        {
            InitializeComponent();
        }

        public WinUjfelvetelizo(Felvetelizo ujdiak) : this()
        {
            this.felvetelizoAdatai = ujdiak;

            this.Title = $"{felvetelizoAdatai.Neve} adataink rögzítése";
            txtNeve.Text = felvetelizoAdatai.Neve;
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            felvetelizoAdatai.OM_Azonosito = txtOMazonosito.Text;
            felvetelizoAdatai.Neve = txtNeve.Text;
            felvetelizoAdatai.EretesitesiCime = txtCim.Text;
            felvetelizoAdatai.Email = txtEmail.Text;
            felvetelizoAdatai.SzuletesiDatum = Convert.ToDateTime(txtSzuletesiDatum.Text);

            try
            {
                this.felvetelizoAdatai.Matematika = int.Parse(txtMatematika.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nem számformátum!");
                return;
            }
            if (felvetelizoAdatai.Matematika < 0 || felvetelizoAdatai > 50)
            {
                MessageBox.Show("Nem lehet ennyi pontja!");
                return;
            }

            this.felvetelizoAdatai.Magyar = int.Parse(txtMagyar.Text);
            Close();
        }

    }
}