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
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id)); //Trie par ordre décroissant de numéro dans la bdd

            //Lie le Datagrid avec la collection
            DtgCustomer.ItemsSource = Customers;
            DtgCustomer.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Insertion dans la base de données via la classe passerelle
            //bdd.InsertCustomer(dtpBouclageMagazine.Text, dtpParutionMagazine.Text, dtpPaiementMagazine.Text, Convert.ToDouble(txtBudgetMagazine.Text));

            //Rafraichissement du Datagrid avec le contenu de la base 
            Customers.Clear();
            //Customers = bdd.SelectMagazine();
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id)); //Trie par ordre décroissant de numéro dans la bdd
            DtgCustomer.ItemsSource = Customers;
        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro.
            int i = Customers.IndexOf((Customer)DtgCustomer.SelectedItem);
            Customers.ElementAt(i).Name = txtNameC.Text;
            Customers.ElementAt(i).Firstname = txtFirstName.Text;
            Customers.ElementAt(i).Phone = txtPhoneC.Text;
            Customers.ElementAt(i).Email = txtEmailC.Text;
            Customers.ElementAt(i).Level = Convert.ToInt32(txtEmailC.Text);
            DtgCustomer.Items.Refresh
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //bdd.DeleteCustomer(Convert.ToInt16(txtIdC.Text));

            Customers.Clear();
            //Customers = bdd.SelectContrat();
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id));
            DtgCustomer.ItemsSource = Customers;
            DtgCustomer.SelectedIndex = 0;
        }

        private void DtgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
