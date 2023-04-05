using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ProjetNemo.Classes
{
    public abstract class Bdd
    {
        public static MySqlConnection
                   GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "nemolesmeilleurs";
            string username = "root";
            string password = "";

            return GetDBConnection(host, port, database, username, password);
        }

        private static MySqlConnection conn = GetDBConnection();
        private static bool OpenConnection()
        {
            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

                return false;
            }
        }
        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }


        #region Customer
        public static List<Customer> SelectAllCustomers()
        {
            //Select statement
            string query = "SELECT * FROM customers";

            //Create a list to store the result
            List<Customer> dbCustomers = new List<Customer>();

            //Ouverture connection
            if (OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Customer customerTemp = new Customer(Convert.ToInt16(dataReader["id"]), Convert.ToString(dataReader["name"]), Convert.ToString(dataReader["firstname"]), Convert.ToString(dataReader["phone"]),
                        Convert.ToString(dataReader["email"]), Convert.ToInt16(dataReader["level"]));
                    dbCustomers.Add(customerTemp);
                }

                //fermeture du Data Reader
                dataReader.Close();
                Console.WriteLine(dataReader);

                //fermeture Connection
                CloseConnection();
            }
            //retour de la collection pour être affichée
            return dbCustomers;
        }
        public static List<Customer> SelectClientWhereId(int customer_id)
        {

            string query = "SELECT * FROM customers Where id=" + customer_id;
            List<Customer> dbCustomers = new List<Customer>();
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Customer customerTemp = new Customer(Convert.ToInt16(dataReader["id"]), Convert.ToString(dataReader["name"]), Convert.ToString(dataReader["firstname"]), Convert.ToString(dataReader["phone"]),
                        Convert.ToString(dataReader["email"]), Convert.ToInt16(dataReader["level"]));
                    dbCustomers.Add(customerTemp);
                }
                dataReader.Close();
                Console.WriteLine(dataReader);
                CloseConnection();
            }
            return dbCustomers;
        }
        public static void InsertCustomer(string name, string firstname, string phone, string email, int level)
        {
            //Requête Insertion customer
            string query = "INSERT INTO  customers  (name,  firstname,  phone,  email, level) " +
                "VALUES('" + name + "','" + firstname + "','" + phone + "','" + email + "'," + level + ")";
            Console.WriteLine(query);
            if (OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();
                Console.WriteLine("Le client à été ajouté");
                CloseConnection();

            }
        }
        public static void DeleteCustomer(int customer_id)
        {
            //Delete Customer
            string query = "DELETE FROM customers WHERE id=" + customer_id;

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Le client à été supprimé");
                CloseConnection();
            }
        } 
        public static void UpdateCustomer(int customer_id, string name, string fistname, string phone, string email, int level)
        {
            //Requête Update customers
            string query = "UPDATE clients SET name='" + name + "',  fistname='" + fistname + "',  phone='" + phone + "',  email='" + email + "', level='" + level +
                "' WHERE id=" + customer_id;
            Console.WriteLine(query);
            //Console.WriteLine(Bdd.OpenConnection());
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();
                Console.WriteLine("Le client à été modifié");
                Bdd.CloseConnection();

            }
        }
        #endregion

    }
}