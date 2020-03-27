using HuizenAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4Api.Models
{
    public class Huis
    {
        public int Id { get; set; }
        public Locatie Locatie { get; set; }
        public string KorteBeschrijving { get; set; }
        public double Price { get; set; }
        public Detail Details { get; set; }
        public Status Status { get; set; }
        public TypeHuis TypeHuis { get; set; }

        public Huis(int id, Locatie locatie, string korteBeschrijving, double price, Detail details, Status status, TypeHuis typeHuis)
        {
            Id = id;
            Locatie = locatie;
            KorteBeschrijving = korteBeschrijving;
            Price = price;
            Details = details;
            Status = status;
            TypeHuis = typeHuis;
        }
    }
}
