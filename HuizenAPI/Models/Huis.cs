using HuizenAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class Huis : ITypeHuis
    {
        public int Id { get; set; }
        public Locatie Locatie { get; set; }
        public string KorteBeschrijving { get; set; }
        public double Price { get; set; }
        public Detail Details { get; set; }

        public Huis(int id, Locatie locatie, string korteBeschrijving, double price, Detail details)
        {
            Id = id;
            Locatie = locatie;
            KorteBeschrijving = korteBeschrijving;
            Price = price;
            Details = details;
        }

        public string GetTypeHuis()
        {
            throw new NotImplementedException();
        }

        public double GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
