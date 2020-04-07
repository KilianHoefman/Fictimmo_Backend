namespace HuizenAPI.Models
{
    public class Favorieten
    {
        public int Id { get; set; }
        public Klant Klant { get; set; }
        public Huis Huis { get; set; }

        public Favorieten()
        {
        }

        public Favorieten(Klant klant, Huis huis) : this()
        {
            Klant = klant;
            Huis = huis;
        }
    }
}
