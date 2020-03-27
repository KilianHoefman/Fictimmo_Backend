using System;

namespace Web4Api.Models
{
    public class Detail
    {
        private string _langeBeschrijving;
        private int _bewoonbareOppervlakte;
        private int _totaleOppervlakte;
        private int _epcWaarde;
        private int _kadastraalInkomen;

        #region Properties
        public string LangeBeschrijving
        {
            get
            {
                return _langeBeschrijving;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Een detail moet een lange beschrijving bevatten");
                _langeBeschrijving = value;
            }
        }
        public int BewoonbareOppervlakte {
            get
            {
                return _bewoonbareOppervlakte;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Bewoonbare oppervlakte moet positief zijn en mag niet gelijk zijn aan nul");
                _bewoonbareOppervlakte = value;
            }
        }
        public int TotaleOppervlakte {
            get
            {
                return _totaleOppervlakte;
            }
            set
            {
                if (value <= 0 || value < _bewoonbareOppervlakte)
                    throw new ArgumentException("Bewoonbare oppervlakte mag niet kleiner of " +
                        "gelijk zijn aan nul en moet minstens evenveel bedragen als de bewoonbare oppervlakte");
            }
        }
        public int EPCWaarde {
            get
            {
                return _epcWaarde;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("EPC moet minstens 1 bedragen");
                _epcWaarde = value;
            }
        }
        public int KadastraalInkomen {
            get
            {
                return _kadastraalInkomen;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Kadastraal inkomen kan niet kleiner of gelijk zijn aan nul");
                _kadastraalInkomen = value;
            }
        }
        #endregion

        public Detail(string langeBeschrijving, int bewoonbareOppervlakte, int totaleOppervlakte, int epcWaarde, int kadastraalInkomen)
        {
            LangeBeschrijving = langeBeschrijving;
            BewoonbareOppervlakte = bewoonbareOppervlakte;
            TotaleOppervlakte = totaleOppervlakte;
            EPCWaarde = epcWaarde;
            KadastraalInkomen = kadastraalInkomen;
        }
    }
}