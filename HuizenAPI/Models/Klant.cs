using System;
using System.Collections.Generic;

namespace HuizenAPI.Models
{
    public class Klant
    {
        #region Fields
        private int _klantenNummer;
        private string _voornaam;
        private string _achternaam;
        //private DateTime _geboorteDatum;
        private string _email;
        #endregion

        public int KlantenNummer
        {
            get
            {
                return _klantenNummer;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Klantennummer mag niet kleiner of gelijk zijn aan nul");
                _klantenNummer = value;
            }
        }
        public string Voornaam
        {
            get
            {
                return _voornaam;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Voornaam mag niet leeg zijn");
                _voornaam = value;
            }
        }
        public string Achternaam
        {
            get
            {
                return _achternaam;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Achternaam mag niet leeg zijn");
                _achternaam = value;
            }
        }
        //public DateTime GeboorteDatum {
        //    get
        //    {
        //        return _geboorteDatum;
        //    }
        //    set
        //    {
        //        if (value == null)
        //            throw new ArgumentException("Geboortedatum moet ingevuld zijn");
        //        _geboorteDatum = value;
        //    }
        //}
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("emailadres mag geen leeg gegeven zijn");
                _email = value;
            }
        }
        #region constructor
        public Klant()
        {

        }

        public Klant(string voornaam, string achternaam, string email) : this()
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            //GeboorteDatum = geboorteDatum;
            Email = email;
        }
        #endregion

        #region methods
        #endregion
    }
}
