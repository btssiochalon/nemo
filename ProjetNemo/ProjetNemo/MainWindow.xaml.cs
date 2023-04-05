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
        List<Customer> Customers = Bdd.SelectAllCustomers();

        public MainWindow()
        {

            InitializeComponent();
            Console.WriteLine(Customers[1].Name);
            //Customers = bdd.SelectCustomer(); //Ajouts des données de la bdd
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id)); //Trie par ordre décroissant de numéro dans la bdd

            //Lie le Datagrid avec la collection
            DtgCustomer.ItemsSource = Customers;
            DtgCustomer.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Insertion dans la base de données via la classe passerelle
            //bdd.InsertCustomer());

            //Rafraichissement du Datagrid avec le contenu de la bdd 
            Customers.Clear();
            //Customers = bdd.SelectCustomer();
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id)); //Trie par ordre décroissant de numéro dans la bdd
            DtgCustomer.ItemsSource = Customers;
        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro.
            int i = Customers.IndexOf((Customer)DtgCustomer.SelectedItem);
            Customers.ElementAt(i).Name = TxtNameC.Text;
            Customers.ElementAt(i).Firstname = TxtFirstnameC.Text;
            Customers.ElementAt(i).Phone = TxtPhoneC.Text;
            Customers.ElementAt(i).Email = TxtMailC.Text;
            Customers.ElementAt(i).Level = Convert.ToInt32(TxtMailC.Text);
            DtgCustomer.Items.Refresh();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //bdd.DeleteCustomer(Convert.ToInt16(TxtIdC.Text));

            Customers.Clear();
            //Customers = bdd.SelectCustomer();
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id));
            DtgCustomer.ItemsSource = Customers;
            DtgCustomer.SelectedIndex = 0;
        }

        private void DtgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Stockage dans l'objet selectedCustomer le Customer selectionné dans le datagrid DtgCustomer
            Customer selectedCustomer = DtgCustomer.SelectedItem as Customer;

            try
            {
                //Remplissage des Textboxs avec les données de l'objet Customer selectedCustomer récupéré dans le Datagrid DtgCustomer
                TxtIdC.Text = Convert.ToString(selectedCustomer.Id);
                TxtFirstnameC.Text = selectedCustomer.Firstname;
                TxtNameC.Text = selectedCustomer.Name;
                TxtPhoneC.Text = selectedCustomer.Phone;
                TxtMailC.Text = selectedCustomer.Email;
                TxtLevelC.Text = Convert.ToString(selectedCustomer.Level);
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid DtgCustomer");
            }
        }
    }
}
