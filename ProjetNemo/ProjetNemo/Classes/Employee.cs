using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNemo.Classes
{
    public class Employee
    {
        #region Champs
        private int id;
        private string name;
        private string firstname;
        private string phone;
        private string email;
        private int job;

        #endregion
        #region Accesseurs/Mutateurs
        public string JobName
        {
            get { return getJobString(); }
        }
       

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }


        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Job
        {
            get { return job; }
            set { job = value; }
        }

        #endregion
        #region Constructeurs
        public Employee(int _id, string _name, string _firstname, string _phone, string _email, int _job)
        {
            id = _id;
            name = _name;
            firstname = _firstname;
            phone = _phone;
            email = _email;
            job = _job;
        }
        #endregion
        #region Méthodes
        override public string ToString()
        {
            // Méthode ToString() surchargée qui écrase la méthode ToString() de base
            return name + " " + firstname;
        }

        string jobString;
        public string getJobString()
        {
            switch(Job)
            {
                case 0:
                    jobString = "Gérant";
                    break;
                case 1:
                    jobString = "Moniteur";
                    break;
                case 2:
                    jobString = "Marin";
                    break;
                case 3:
                    jobString = "Secrétaire";
                    break;
                case 4:
                    jobString = "Stagiaire";
                    break;
            }
            return jobString;
               
        }
        #endregion
    }
}
