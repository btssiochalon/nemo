using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Client
    {
        #region Champs
        private int _idcli;
        private string _nomcli;
        private string _prenomcli;
        private string _mailcli;
        private string _villecli;
        private string _nomruecli;
        private int _cpcli;
        private int _idprospect;
        #endregion

        #region Constructeur
        public Client(int p_idcli,string p_nomcli,string p_prenomcli,string p_mailcli,string p_villecli,string p_nomruecli,int p_cpcli,int p_idprospect)
        {
            _idcli = p_idcli;
            _nomcli = p_nomcli;
            _prenomcli = p_prenomcli;
            _mailcli =  p_mailcli;
            _villecli = p_villecli;
            _nomruecli = p_nomruecli;
            _cpcli = p_cpcli;
            _idprospect = p_idprospect;

        }
        #endregion

        #region Accesseurs/Mutateurs
        public int IdProspect
        {
            get { return _idprospect; }
            set { _idprospect = value; }
        }


        public int CPCli
        {
            get { return _cpcli; }
            set { _cpcli = value; }
        }


        public string NomRueCli
        {
            get { return _nomruecli; }
            set { _nomruecli = value; }
        }


        public string VilleCli
        {
            get { return _villecli; }
            set { _villecli = value; }
        }


        public string MailCli
        {
            get { return _mailcli; }
            set { _mailcli = value; }
        }


        public string PrenomCli
        {
            get { return _prenomcli; }
            set { _prenomcli = value; }
        }


        public string NomCli
        {
            get { return _nomcli; }
            set { _nomcli = value; }
        }


        public int IdCli
        {
            get { return _idcli; }
            set { _idcli = value; }
        }
        #endregion

    }
}
