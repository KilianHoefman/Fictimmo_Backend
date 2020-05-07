using System;
using GoogleMaps.LocationServices;

namespace HuizenAPI.Models
{
    public class Locatie
    {
        #region Fields
        private int _locatieId;
        private string _gemeente;
        private string _straatnaam;
        private string _huisnummer;
        private int _postcode;
        private double _latitude;
        private double _longitude;
        #endregion

        #region Properties
        public int LocatieId
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
        public double Latitude
        {
            get => _latitude; 
            set
            {
                _latitude = value;
            }
        }

        public double Longitude {
            get => _longitude;
            set
            {
                _longitude = value;
            }
        }
        #endregion

        #region constructors
        public Locatie() { }
        public Locatie(string gemeente, string straatnaam, string huisnummer, int postcode)
        {
            Gemeente = gemeente;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
            ConvertAddress(gemeente, straatnaam, huisnummer);
        }
        #endregion

        #region Methods
        public void ConvertAddress(string gemeente, string straatnaam, string huisnummer)
        {
            var address = string.Concat(gemeente, ", ", straatnaam, ", ", huisnummer);

            string apiKey = "AIzaSyDHBSjAv1T_S0_g_VjpsFXMWSuk3UDYHeE";

            var locationService = new GoogleLocationService(apiKey);
            var point = locationService.GetLatLongFromAddress(address);

            _latitude = point.Latitude;
            _longitude = point.Longitude;

            Console.WriteLine("lat: " + _latitude);
            Console.WriteLine("lon: " + _longitude);
        }
        #endregion
    }
}