using System;

namespace Web4Api.Models
{
    public class Locatie
    {
        #region Fields
        private int _locatieId;
        private string _gemeente;
        private string _straatnaam;
        private string _huisnummer;
        private int _postcode;        
        #endregion

        #region Properties
        public int LocatieID
        {
            get
            {
                return _locatieId;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("LocatieID mag niet kleiner zijn dan nul");
                _locatieId = value;
            }
        }
        public string Gemeente {
            get
            {
                return _gemeente;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Gemeente mag geen leeg gegeven zijn");
                _gemeente = value;
            }
        }
        public string Straatnaam {
            get
            {
                return _straatnaam;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Straatnaam mag geen leeg gegeven zijn");
                _straatnaam = value;
            }
        }
        public string Huisnummer {
            get
            {
                return _huisnummer;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Huisnummer mag geen leeg gegeven zijn");
                _huisnummer = value;
            }
        }
        public int Postcode {
            get
            {
                return _postcode;
            }
            set
            {
                if (value < 1000 || value > 9999)
                    throw new ArgumentException("Postcode moet uit 4 cijfers bestaan");
                _postcode = value;
            }
        }
       // public Huis Huis { get; set; }
        #endregion

        #region constructors
        public Locatie() { }
        public Locatie(int locatieId, string gemeente, string straatnaam, string huisnummer, int postcode)
        {
            LocatieID = locatieId;
            Gemeente = gemeente;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
        }
        #endregion
    }
}