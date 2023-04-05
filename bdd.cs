using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace CRM
{
    class bdd
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        private static string port;

        //Initialisation des valeurs
        public static void Initialize()
        {
            server = "172.31.200.3";
            database = "InfoTools";
            uid = "prog";
            password = "root";
            port = "3306";
            string connectionString = "server=" + server + ";" + "port=" + port + ";" + "database=" + database + ";" + "uid=" + uid + ";" + "password=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.WriteLine("Erreur connexion BDD");
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //--------------------------------------------------------------------PRODUIT----------------------------------------------
        public static List<Produit> SelectProduitById(int idprod)
        {
            //Select statement
            string query = "SELECT * FROM produit where idProd = " + idprod;

            //Create a list to store the result
            List<Produit> dbProduit = new List<Produit>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Produit leProduit = new Produit(Convert.ToInt16(dataReader["IdProd"]), Convert.ToString(dataReader["TypeProd"]), Convert.ToInt32(dataReader["PrixProd"]), Convert.ToString(dataReader["NomProd"]), Convert.ToString(dataReader["DescProd"]));
                    dbProduit.Add(leProduit);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbProduit;
        }
        public static List<Produit> SelectProduit()
        {
            //Select statement
            string query = "SELECT * FROM produit";

            //Create a list to store the result
            List<Produit> dbProduit = new List<Produit>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Produit leProduit = new Produit(Convert.ToInt16(dataReader["IdProd"]), Convert.ToString(dataReader["TypeProd"]), Convert.ToInt32(dataReader["PrixProd"]), Convert.ToString(dataReader["NomProd"]), Convert.ToString(dataReader["DescProd"]));
                    dbProduit.Add(leProduit);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbProduit;
        }
        public static void InsertProduit(string typeP, int prixP, string nomP, string descP)
        {
            //Requête Insertion Produit
            string query = "INSERT INTO produit (TypeProd, PrixProd, NomProd, DescProd) VALUES('" + typeP + "','" + prixP + "','" + nomP + "','" + descP + "')";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try 
                {
                    cmd.ExecuteNonQuery();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void UpdateProduit(int idP, string typeP, int prixP, string nomP, string descP)
        {
            //Update Produit
            string query = "UPDATE produit SET TypeProd='" + typeP + "', PrixProd=" + prixP + ", NomProd ='" + nomP + "', DescProd ='" + descP + "' WHERE IdProd=" + idP;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    bdd.CloseConnection();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }
            }
        }
        public static void DeleteProduit(int id)
        {
            //Delete Produit
            string query = "DELETE FROM produit WHERE IdProd=" + id;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }
        //--------------------------------------------------------------------EMPLOYE----------------------------------------------
        public static List<Employe> SelectEmployeById(int idemp)
        {
            //Select statement
            string query = "SELECT * FROM employe where IdEmp = " + idemp;

            //Create a list to store the result
            List<Employe> dbEmploye = new List<Employe>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Employe leEmploye = new Employe(Convert.ToInt16(dataReader["IdEmp"]), Convert.ToString(dataReader["NomEmp"]), Convert.ToString(dataReader["PrenomEmp"]), Convert.ToString(dataReader["TelEmp"]), Convert.ToString(dataReader["MailEmp"]), Convert.ToString(dataReader["PosteEmp"]));
                    dbEmploye.Add(leEmploye);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbEmploye;
        }
        public static List<Employe> SelectEmploye()
        {
            //Select statement
            string query = "SELECT * FROM employe";

            //Create a list to store the result
            List<Employe> dbEmploye = new List<Employe>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Employe leEmploye = new Employe(Convert.ToInt16(dataReader["IdEmp"]), Convert.ToString(dataReader["NomEmp"]), Convert.ToString(dataReader["PrenomEmp"]), Convert.ToString(dataReader["TelEmp"]), Convert.ToString(dataReader["MailEmp"]), Convert.ToString(dataReader["PosteEmp"]));
                    dbEmploye.Add(leEmploye);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbEmploye;
        }
        public static void InsertEmploye(string nom, string prenom, string tel, string mail, string poste)
        {
            //Requête Insertion Employé
            string query = "INSERT INTO employe (NomEmp, PrenomEmp, TelEmp, MailEmp, PosteEmp) VALUES('" + nom + "','" + prenom + "','" + tel + "','" + mail + "','" + poste + "')";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void UpdateEmploye(int id, string nom, string prenom, string tel, string mail, string poste)
        {
            //Update Employé
            string query = "UPDATE employe SET NomEmp='" + nom + "', PrenomEmp='" + prenom + "', TelEmp ='" + tel + "', MailEmp ='" + mail + "', PosteEmp ='" + poste + "' WHERE IdEmp=" + id;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    bdd.CloseConnection();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }
            }
        }
        public static void DeleteEmploye(int id)
        {
            //Delete Employé
            string query = "DELETE FROM employe WHERE IdEmp=" + id;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }
        //--------------------------------------------------------------------CLIENT----------------------------------------------
        public static List<Client> SelectClientById(int idcli)
        {
            //Select statement
            string query = "SELECT * FROM client where IdCli = " + idcli;

            //Create a list to store the result
            List<Client> dbClient = new List<Client>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Client leClient = new Client(Convert.ToInt16(dataReader["IdCli"]), Convert.ToString(dataReader["NomCli"]), Convert.ToString(dataReader["PrenomCli"]), Convert.ToString(dataReader["MailCli"]), Convert.ToString(dataReader["VilleCli"]), Convert.ToString(dataReader["NomRueCli"]), Convert.ToInt32(dataReader["CPCli"]), Convert.ToInt32(dataReader["IdProspect"]));
                    dbClient.Add(leClient);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbClient;
        }
        public static List<Client> SelectClient()
        {
            //Select statement
            string query = "SELECT * FROM client";

            //Create a list to store the result
            List<Client> dbClient = new List<Client>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Client leClient = new Client(Convert.ToInt16(dataReader["IdCli"]), Convert.ToString(dataReader["NomCli"]), Convert.ToString(dataReader["PrenomCli"]), Convert.ToString(dataReader["MailCli"]), Convert.ToString(dataReader["VilleCli"]), Convert.ToString(dataReader["NomRueCli"]), Convert.ToInt32(dataReader["CPCli"]), Convert.ToInt32(dataReader["IdProspect"]));
                    dbClient.Add(leClient);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbClient;
        }
        public static void InsertClient(string nom, string prenom, string mail, string ville, string adresse, int cp, int prospect)
        {
            //Requête Insertion Client
            string query = "INSERT INTO client (NomCli, PrenomCli, MailCli, VilleCli, NomRueCli, CPCli, IdProspect) VALUES('" + nom + "','" + prenom + "','" + mail + "','" + ville + "','" + adresse + "','" + cp + "','" + prospect + "')";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void UpdateClient(int id, string nom, string prenom, string mail, string ville, string adresse, int cp, int prospect)
        {
            //Update Client
            string query = "UPDATE client SET NomCli='" + nom + "', PrenomCli='" + prenom + "', MailCli ='" + mail + "', VilleCli ='" + ville + "', NomRueCli ='" + adresse + "', CPCli ='" + cp + "', IdProspect ='" + prospect + "'  WHERE IdCli=" + id;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    bdd.CloseConnection();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }
            }
        }
        public static void DeleteClient(int id)
        {
            //Delete Client
            string query = "DELETE FROM client WHERE IdCli=" + id;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }
        //--------------------------------------------------------------------RDV----------------------------------------------
        public static List<Rdv> SelectRdvById(int idrdv)
        {
            //Select statement
            string query = "SELECT * FROM rdv where idRdv = " + idrdv;

            //Create a list to store the result
            List<Rdv> dbRdv = new List<Rdv>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Rdv leRdv = new Rdv(Convert.ToInt32(dataReader["IdRdv"]), Convert.ToInt32(dataReader["IdCli"]), Convert.ToInt32(dataReader["IdEmp"]), Convert.ToString(dataReader["DateRdv"]), Convert.ToString(dataReader["HeureRdv"]));
                    dbRdv.Add(leRdv);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbRdv;
        }
        public static List<Rdv> SelectRdv()
        {
            //Select statement
            string query = "SELECT * FROM rdv";

            //Create a list to store the result
            List<Rdv> dbRdv = new List<Rdv>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Rdv leRdv = new Rdv(Convert.ToInt32(dataReader["IdRdv"]), Convert.ToInt32(dataReader["IdCli"]), Convert.ToInt32(dataReader["IdEmp"]), Convert.ToString(dataReader["DateRdv"]), Convert.ToString(dataReader["HeureRdv"]));
                    dbRdv.Add(leRdv);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
            }
            return dbRdv;
        }
        public static void InsertRdv(int idcli, int idemp, string date, string heure)
        {
            //Requête Insertion Rdv
            string query = "INSERT INTO Rdv (IdCli, IdEmp, DateRdv, HeureRdv) VALUES('" + idcli + "','" + idemp + "','" + date + "','" + heure + "')";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void UpdateRdv(int id, int idcli, int idemp, string date, string heure)
        {
            //Update Rdv
            string query = "UPDATE Rdv SET IdCli=" + idcli + ", IdEmp=" + idemp + ", DateRdv =" + date + ", HeureRdv =" + heure + "WHERE IdRdv=" + id;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    bdd.CloseConnection();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }
            }
        }
        public static void DeleteRdv(int id)
        {
            //Delete Rdv
            string query = "DELETE FROM Rdv WHERE IdRdv=" + id;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }
    }
}
