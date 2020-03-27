namespace Web4Api.Models
{
    public class Locatie
    {
        public string Gemeente { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnummer { get; set; }
        public int Postcode { get; set; }

        public Locatie(string gemeente, string straatnaam, string huisnummer, int postcode)
        {
            Gemeente = gemeente;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
        }
    }
}