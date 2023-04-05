using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Employe
    {
        #region Champs
        private int _idemp;
        private string _nomemp;
        private string _prenomemp;
        private string _telemp;
        private string _mailemp;
        private string _posteemp;
        #endregion

        #region Constructeur
        public Employe(int p_idemp, string p_nomemp, string p_prenomemp, string p_telemp, string p_mailemp, string p_posteemp)
        {
            _idemp = p_idemp;
            _nomemp = p_nomemp;
            _prenomemp = p_prenomemp;
            _telemp = p_telemp;
            _mailemp = p_mailemp;
            _posteemp = p_posteemp;
        }
        #endregion


        #region Accesseurs/Mutateurs
        public string PosteEmp
        {
            get { return _posteemp; }
            set { _posteemp = value; }
        }


        public string MailEmp
        {
            get { return _mailemp; }
            set { _mailemp = value; }
        }


        public string TelEmp
        {
            get { return _telemp; }
            set { _telemp = value; }
        }

        public string PrenomEmp
        {
            get { return _prenomemp; }
            set { _prenomemp = value; }
        }

        public string NomEmp
        {
            get { return _nomemp; }
            set { _nomemp = value; }
        }


        public int IdEmp
        {
            get { return _idemp; }
            set { _idemp = value; }
        }
        #endregion
    }
}
