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
        List<Employee> Employees = Bdd.SelectAllEmployees();

        public MainWindow()
        {

            InitializeComponent();

            //Ajouts des données de la bdd
            Customers = Bdd.SelectAllCustomers();
            Employees = Bdd.SelectAllEmployees();

            //Trie par ordre décroissant de numéro dans la bdd
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id));
            Employees.Sort((x, y) => 1 * x.Id.CompareTo(y.Id));

            //Lie le Datagrid avec la collection
            DtgCustomer.ItemsSource = Customers;
            DtgCustomer.SelectedIndex = 0;

            DtgEmployee.ItemsSource = Employees;
            DtgEmployee.SelectedIndex = 0;
        }

        //--------------------------------------------------CUSTOMERS------------------------------------------------
        private void BtnAddC_Click(object sender, RoutedEventArgs e)
        {
            //Insertion dans la base de données via la classe passerelle
            Bdd.InsertCustomer(TxtNameC.Text, TxtFirstnameC.Text, TxtPhoneC.Text, TxtMailC.Text, Convert.ToInt32(ComboLevelC.SelectedIndex));

            //Rafraichissement du Datagrid avec le contenu de la bdd 
            Customers.Clear();
            Customers = Bdd.SelectAllCustomers();
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id)); //Trie par ordre décroissant de numéro dans la bdd
            DtgCustomer.ItemsSource = Customers;
        }

        private void BtnModifyC_Click(object sender, RoutedEventArgs e)
        {
            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro.

            Bdd.UpdateCustomer(Convert.ToInt32(TxtIdC.Text), TxtNameC.Text, TxtFirstnameC.Text, TxtPhoneC.Text, TxtMailC.Text, Convert.ToInt32(ComboLevelC.SelectedIndex));
            int i = Customers.IndexOf((Customer)DtgCustomer.SelectedItem);
            Customers.ElementAt(i).Name = TxtNameC.Text;
            Customers.ElementAt(i).Firstname = TxtFirstnameC.Text;
            Customers.ElementAt(i).Phone = TxtPhoneC.Text;
            Customers.ElementAt(i).Email = TxtMailC.Text;
            Customers.ElementAt(i).Level = Convert.ToInt32(ComboLevelC.SelectedIndex);
            DtgCustomer.Items.Refresh();
        }

        private void BtnDeleteC_Click(object sender, RoutedEventArgs e)
        {
            Bdd.DeleteCustomer(Convert.ToInt16(TxtIdC.Text));

            Customers.Clear();
            Customers = Bdd.SelectAllCustomers();
            Customers.Sort((x, y) => 1 * x.Id.CompareTo(y.Id));
            DtgCustomer.ItemsSource = Customers;
            DtgCustomer.SelectedIndex = 0;
        }

        private void DtgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Stockage dans l'objet selectedCustomer le Customer selectionné dans le datagrid DtgCustomer
            Customer selectedCustomer = DtgCustomer.SelectedItem as Customer;

            if (selectedCustomer != null)
            {
                try
                    {
                        //Remplissage des Textboxs avec les données de l'objet Customer selectedCustomer récupéré dans le Datagrid DtgCustomer
                        TxtIdC.Text = Convert.ToString(selectedCustomer.Id);
                        TxtFirstnameC.Text = selectedCustomer.Firstname;
                        TxtNameC.Text = selectedCustomer.Name;
                        TxtPhoneC.Text = selectedCustomer.Phone;
                        TxtMailC.Text = selectedCustomer.Email;
                        ComboLevelC.SelectedIndex = selectedCustomer.Level;
                    }
                catch (Exception)
                    {
                        Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid DtgCustomer");
                    }
            }
            
        }

        //--------------------------------------------------EMPLOYEES------------------------------------------------

        private void BtnAddE_Click(object sender, RoutedEventArgs e)
        {
            //Insertion dans la base de données via la classe passerelle
            Bdd.InsertEmployee(TxtNameE.Text, TxtFirstnameE.Text, TxtPhoneE.Text, TxtMailE.Text, Convert.ToInt32(ComboJobE.SelectedIndex));

            //Rafraichissement du Datagrid avec le contenu de la bdd 
            Employees.Clear();
            Employees = Bdd.SelectAllEmployees();
            Employees.Sort((x, y) => 1 * x.Id.CompareTo(y.Id)); //Trie par ordre décroissant de numéro dans la bdd
            DtgEmployee.ItemsSource = Employees;
        }

        private void BtnModifyE_Click(object sender, RoutedEventArgs e)
        {
            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro.
            Bdd.UpdateEmployee(Convert.ToInt32(TxtIdE.Text), TxtNameE.Text, TxtFirstnameE.Text, TxtPhoneE.Text, TxtMailE.Text, Convert.ToInt32(ComboJobE.SelectedIndex));
            int i = Employees.IndexOf((Employee)DtgEmployee.SelectedItem);
            Employees.ElementAt(i).Name = TxtNameE.Text;
            Employees.ElementAt(i).Firstname = TxtFirstnameE.Text;
            Employees.ElementAt(i).Phone = TxtPhoneE.Text;
            Employees.ElementAt(i).Email = TxtMailE.Text;
            Employees.ElementAt(i).Job = Convert.ToInt32(ComboJobE.SelectedIndex);
            DtgEmployee.Items.Refresh();
        }

        private void BtnDeleteE_Click(object sender, RoutedEventArgs e)
        {
            Bdd.DeleteEmployee(Convert.ToInt16(TxtIdE.Text));

            Employees.Clear();
            Employees = Bdd.SelectAllEmployees();
            Employees.Sort((x, y) => 1 * x.Id.CompareTo(y.Id));
            DtgEmployee.ItemsSource = Employees;
            DtgEmployee.SelectedIndex = 0;
        }

        private void DtgEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Stockage dans l'objet selectedEmployee le Employee selectionné dans le datagrid DtgEmployee
            Employee selectedEmployee = DtgEmployee.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                try
                {
                    //Remplissage des Textboxs avec les données de l'objet Employee selectedEmployee récupéré dans le Datagrid DtgEmployee
                    TxtIdE.Text = Convert.ToString(selectedEmployee.Id);
                    TxtFirstnameE.Text = selectedEmployee.Firstname;
                    TxtNameE.Text = selectedEmployee.Name;
                    TxtPhoneE.Text = selectedEmployee.Phone;
                    TxtMailE.Text = selectedEmployee.Email;
                    ComboJobE.SelectedIndex = selectedEmployee.Job;
                }
                catch (Exception)
                {
                    Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid DtgEmployee");
                }
            }

        }
    }
}
