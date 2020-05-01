using System;
using System.Collections.Generic;
using System.Linq;

namespace HuizenAPI.Models
{
    public class ImmoBureau
    {
        private int _id;
        private string _naam;

        public int ImmoBureauId
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Naam
        {
            get
            {
                return _naam;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Immobureau moet een naam hebben en deze mag niet leeg zijn");
                _naam = value;
            }
        }

        #region constructors
        public ImmoBureau()
        {

        }

        public ImmoBureau(string naam) : this()
        {
            Naam = naam;
        }
        #endregion
    }
}
