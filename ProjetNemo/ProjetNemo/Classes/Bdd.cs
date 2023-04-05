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
            //Select statement
            string query = "SELECT * FROM customers Where id=" + customer_id;

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
                Bdd.CloseConnection();
            }
            //retour de la collection pour être affichée
            return dbCustomers;
        }
        //public static void InsertClient(string nomC, string prenomC, string mailC, string telC, string villeC, string rueC, string cpC, int prospect)
        //{
        //    //Requête Insertion Magazine
        //    string query = "INSERT INTO  clients  (  NomCli ,  PrenomCli ,  MailCli ,  TelCli, VilleCli, RueCli, CpCli, Prospect ) " +
        //        "VALUES('" + nomC + "','" + prenomC + "','" + mailC + "','" + telC + "','" + villeC + "','" + rueC + "','" + cpC + "'," + prospect + ")";
        //    Console.WriteLine(query);
        //    //Console.WriteLine(Bdd.OpenConnection());
        //    if (Bdd.OpenConnection() == true)
        //    {
        //        //create command and assign the query and connection from the constructor
        //        MySqlCommand cmd = new MySqlCommand(query, conn);

        //        //Execute command
        //        cmd.ExecuteNonQuery();
        //        Console.WriteLine("Le client à été ajouté");
        //        Bdd.CloseConnection();

        //    }
        //}
        //public static void DeleteClient(int numC)
        //{
        //    //Delete Magazine
        //    string query = "DELETE FROM Clients WHERE id=" + numC;

        //    if (Bdd.OpenConnection() == true)
        //    {
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        cmd.ExecuteNonQuery();
        //        Console.WriteLine("Le client à été supprimé");
        //        Bdd.CloseConnection();
        //    }
        //}
        //public static void UpdateClient(int numC, string nomC, string prenomC, string mailC, string telC, string villeC, string rueC, string cpC, int prospect)
        //{
        //    //Requête Insertion Magazine
        //    string query = "UPDATE clients SET NomCli='" + nomC + "',  PrenomCli='" + prenomC + "',  MailCli='" + mailC + "',  TelCli='" + telC + "', VilleCli='" + villeC + "', RueCli='" + rueC + "', CpCli='" + cpC + "', Prospect=" + prospect + " " +
        //        "WHERE id=" + numC;
        //    Console.WriteLine(query);
        //    //Console.WriteLine(Bdd.OpenConnection());
        //    if (Bdd.OpenConnection() == true)
        //    {
        //        //create command and assign the query and connection from the constructor
        //        MySqlCommand cmd = new MySqlCommand(query, conn);

        //        //Execute command
        //        cmd.ExecuteNonQuery();
        //        Console.WriteLine("Le client à été modifié");
        //        Bdd.CloseConnection();

        //    }
        //}
        #endregion

    }
}