using System;

namespace HuizenAPI.Models
{
    public class Huis
    {
        private Locatie _locatie;
        private string _korteBeschrijving;
        private int _price;
        private Detail _detail;
        private string _type;
        private string _soort;
        private ImmoBureau _immoBureau;

        public int Id
        {
            get; set;
        }
        public Locatie Locatie
        {
            get
            {
                return _locatie;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Locatie mag niet leeg zijn");
                _locatie = value;
            }
        }
        public string KorteBeschrijving
        {
            get
            {
                return _korteBeschrijving;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Korte beschrijving mag geen leeg gegeven zijn");
                _korteBeschrijving = value;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Prijs mag niet kleiner of gelijk zijn aan nul");
                _price = value;
            }
        }
        public Detail Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Details mag geen leeg gegeven zijn");
                _detail = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Type mag niet leeg zijn");
                if (string.Equals(value, "koop", StringComparison.OrdinalIgnoreCase) || string.Equals(value, "huur", StringComparison.OrdinalIgnoreCase))
                    _type = value;
                else
                    throw new ArgumentException("Fout in setter type...");
                //CHANGE
            }
        }

        public string Soort
        {
            get
            {
                return _soort;
            }
            set
            {

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Soort mag niet leeg zijn");
                _soort = value;
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

        #region constructors
        public Huis() { }
        public Huis(Locatie locatie, string korteBeschrijving, int price, Detail detail, string type, string soort, ImmoBureau immoBureau)
        {
            Locatie = locatie;
            KorteBeschrijving = korteBeschrijving;
            Price = price;
            Detail = detail;
            Type = type;
            Soort = soort;
            ImmoBureau = immoBureau;
        }
        #endregion
    }
}
