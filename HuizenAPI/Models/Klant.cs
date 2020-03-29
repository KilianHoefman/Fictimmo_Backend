using HuizenAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Web4Api.Models;

namespace HuizenAPI.Models
{
    public class Klant
    {
        #region Fields
        private int _klantenNummer;
        private string _voornaam;
        private string _achternaam;
        private DateTime _geboorteDatum;
        private string _email; 
        private string _telefoonNummer;
        private ImmoBureau _immoBureau;
        #endregion

        public int KlantenNummer {
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
        public string Voornaam {
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
        public string Achternaam {
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
        public DateTime GeboorteDatum {
            get
            {
                return _geboorteDatum;
            }
            set
            {
                if (value == null || value.Year > 2002)
                    throw new ArgumentException("Geboortedatum mag later zijn dan 2002 en moet ingevuld zijn");
                _geboorteDatum = value;
            }
        }
        public string Email {
            get
            {
                return _email;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("emailadres mag geen leeg gegeven zijn");
                _email = value;
            }
        }
        public string TelefoonNummer {
            get
            {
                return _telefoonNummer;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Telefoonnummer mag geen leeg gegeven zijn");
                _telefoonNummer = value;
            }
        }
        public ImmoBureau ImmoBureau
        {
            get
            {
                return _immoBureau;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Immobureau mag geen leeg gegeven zijn");
                _immoBureau = value;
            }
        }
        public List<Huis> FavorieteHuizen;

        #region constructor
        public Klant()
        {
            FavorieteHuizen = new List<Huis>();
        }

        public Klant(string voornaam, string achternaam, DateTime geboorteDatum, string email, string telefoonNummer, ImmoBureau immoBureau) : this()
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            GeboorteDatum = geboorteDatum;
            Email = email;
            TelefoonNummer = telefoonNummer;
            ImmoBureau = immoBureau;
        }
        #endregion
    }
}
