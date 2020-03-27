using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class Klant
    {
        public int KlantenNummer { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public List<Huis> FavorieteHuizen;

        public Klant()
        {
            FavorieteHuizen = new List<Huis>();
        }

        public Klant(int klantenNummer, string voornaam, string achternaam, DateTime geboorteDatum, string email, string telefoonNummer) : this()
        {
            KlantenNummer = klantenNummer;
            Voornaam = voornaam;
            Achternaam = achternaam;
            GeboorteDatum = geboorteDatum;
            Email = email;
            TelefoonNummer = telefoonNummer;
        }
    }
}
