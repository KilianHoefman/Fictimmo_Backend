using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuizenAPI.Data.Repositories;
using HuizenAPI.DTOs;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web4Api.Models;

namespace HuizenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuizenController : ControllerBase
    {
        private readonly IHuisRepository _huisRepository;

        public HuizenController(IHuisRepository context)
        {
            _huisRepository = context;
        }

        /// <summary>
        /// Geef alle huizen op prijs en/of type
        /// </summary>
        /// <param name="price">Prijs van het huis als int</param>
        /// <param name="type">Type van het huis (koop of huur) als string</param>
        /// <returns>Array van huizen</returns>
        [HttpGet]
        public IEnumerable<Huis> GetHuizen(int? price = null, string type = null)
        {
            if (price == null && string.IsNullOrEmpty(type))
                return _huisRepository.GetAll();
            return _huisRepository.GetBy(price, type);
        }

        /// <summary>
        /// Geef het huis met id
        /// </summary>
        /// <param name="id">Id van het huis als int</param>
        /// <returns>Het huis</returns>
        [HttpGet("{id}")]
        public ActionResult<Huis> GetHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null)
                return NotFound();
            return huis;
        }

        [HttpGet("GetDetailVoorHuis")]
        public ActionResult<Detail> GetDetailVoorHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null) return NotFound();
            return huis.Detail;
        }

        [HttpGet("GetLocatieVoorHuis")]
        public ActionResult<Locatie> GetLocatieVoorHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null) return NotFound();
            return huis.Locatie;
        }

        [HttpGet("GetImmoBureauVoorHuis")]
        public ActionResult<ImmoBureau> GetImmoBureaVoorHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null) return NotFound();
            return huis.ImmoBureau;
        }

        /// <summary>
        /// Geef huizen met bepaald immobureau
        /// </summary>
        /// <param name="Naam">Naam als string</param>
        /// <returns>Array van huizen met gespecifieerd immobureau</returns>
        [HttpGet("immoBureau")]
        public IEnumerable<Huis> GetByImmoBureau(string Naam)
        {
            return _huisRepository.GetByImmoBureau(Naam);
        }

        /// <summary>
        /// Geef huizen met bepaalde locatie adhv postcode of gemeente
        /// </summary>
        /// <param name="Postcode">Postcode als int</param>
        /// <param name="Gemeente">Gemeente als string</param>
        /// <returns>Array van huizen die voldoen aan postcode of gemeente</returns>
        [HttpGet("Locatie")]
        public IEnumerable<Huis> GetByLocatie(int? Postcode, string Gemeente)
        {
            return _huisRepository.GetByLocatie(Postcode, Gemeente);
        }

        /// <summary>
        /// Voegt een nieuw huis toe
        /// </summary>
        /// <param name="huisDTO">DTO van huis met info</param>        
        [HttpPost]
        public ActionResult<Huis> PostHuis(HuisDTO huisDTO)
        {
            Locatie locatie = new Locatie(huisDTO.LocatieDTO.Gemeente, huisDTO.LocatieDTO.Straatnaam, huisDTO.LocatieDTO.Huisnummer, huisDTO.LocatieDTO.Postcode);
            Detail detail = new Detail(huisDTO.DetailDTO.LangeBeschrijving, huisDTO.DetailDTO.BewoonbareOppervlakte, huisDTO.DetailDTO.TotaleOppervlakte, huisDTO.DetailDTO.EPCWaarde, huisDTO.DetailDTO.KadastraalInkomen);
            ImmoBureau immoBureau = new ImmoBureau(huisDTO.ImmoBureauDTO.Naam);
            Huis huis = new Huis(locatie, huisDTO.KorteBeschrijving, huisDTO.Price, detail, huisDTO.Type, immoBureau);
            _huisRepository.Add(huis);
            _huisRepository.SaveChanges();

            return CreatedAtAction(nameof(GetHuis), new { id = huis.Id }, huis);
        }

        /// <summary>
        /// Wijzigt een huis
        /// </summary>
        /// <param name="id">id van het huis dat gewijzigd dient te worden als int</param>
        /// <param name="huis">Het te wijzigen huis</param>        
        [HttpPut("{id}")]
        public IActionResult PutHuis(int id, Huis huis)
        {
            if(id != huis.Id)
            {
                return BadRequest();
            }
            _huisRepository.Update(huis);
            _huisRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if(huis == null)
            {
                return NotFound();
            }
            _huisRepository.Delete(huis);
            _huisRepository.SaveChanges();
            return NoContent();
        }

    }
}