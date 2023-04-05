using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Rdv
    {
        #region Champs
        private int _idrdv;
        private int _leclient;
        private int _leemploye;
        private string _daterdv;
        private string _heurerdv;
        #endregion

        #region Constructeur
        public Rdv(int p_idrdv, int p_leclient, int p_leemploye, string p_daterdv, string p_heurerdv)
        {
            _idrdv = p_idrdv;
            _leclient = p_leclient;
            _leemploye = p_leemploye;
            _daterdv = p_daterdv;
            _heurerdv = p_heurerdv;
        }
        #endregion
        #region Accesseurs/Mutateurs
        public string HeureRdv
        {
            get { return _heurerdv; }
            set { _heurerdv = value; }
        }
        public string DateRdv
        {
            get { return _daterdv; }
            set { _daterdv = value; }
        }
        public int LeEmploye
        {
            get { return _leemploye; }
            set { _leemploye = value; }
        }
        public int LeClient
        {
            get { return _leclient; }
            set { _leclient = value; }
        }
        public int IdRdv
        {
            get { return _idrdv; }
            set { _idrdv = value; }
        }
        #endregion
    }
}
