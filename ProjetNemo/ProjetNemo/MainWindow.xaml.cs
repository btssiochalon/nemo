using ProjetNemo.Classes;
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

namespace ProjetNemo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Création Listes
        List<Customer> Customers = new List<Customer>();

        public MainWindow()
        {
            InitializeComponent();

            //Customers = bdd.SelectMagazine(); //Ajouts des données de la bdd
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id)); //Trie par ordre croissant

            //Lie le Datagrid avec la collection
            DtgCustomer.ItemsSource = Customers;
            DtgCustomer.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DtgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
