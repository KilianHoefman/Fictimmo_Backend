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
                /*if (value < 0)
                    throw new ArgumentException("ID mag niet kleiner dan nul zijn");*/
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
        public ICollection<Huis> Huizen { get; set; }

        #region constructors
        public ImmoBureau()
        {
            Huizen = new List<Huis>();
        }

        public ImmoBureau(string naam) : this()
        {
            Naam = naam;
        }
        #endregion

        #region methods
        public void AddHuis(Huis huis)
        {
            Huizen.Add(huis);
        }

        public Huis GetHuis(int id)
        {
            return Huizen.SingleOrDefault(huis => huis.Id == id);
        }
        #endregion
    }
}
