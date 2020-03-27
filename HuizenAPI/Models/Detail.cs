namespace Web4Api.Models
{
    public class Detail
    {
        #region Properties
        public string LangeBeschrijving { get; set; }
        public double BewoonbareOppervlakte { get; set; }
        public double TotaleOppervlakte { get; set; }
        public double EPCWaarde { get; set; }
        public double? KadastraalInkomen { get; set; }
        #endregion

        public Detail(string langeBeschrijving, double bewoonbareOppervlakte, double totaleOppervlakte, double epcWaarde, double kadastraalInkomen)
        {
            LangeBeschrijving = langeBeschrijving;
            BewoonbareOppervlakte = bewoonbareOppervlakte;
            TotaleOppervlakte = totaleOppervlakte;
            EPCWaarde = epcWaarde;
            KadastraalInkomen = kadastraalInkomen;
        }
    }
}