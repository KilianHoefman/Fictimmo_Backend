using HuizenAPI.DTOs;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuizenAPI.Controllers
{
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HuizenController : ControllerBase
    {
        private readonly IHuisRepository _huisRepository;
        private readonly IImmoBureauRepository _bureauRepository;

        public HuizenController(IHuisRepository context, IImmoBureauRepository contextImmo)
        {
            _huisRepository = context;
            _bureauRepository = contextImmo;
        }

        /// <summary>
        /// Geef alle huizen op prijs en/of type
        /// </summary>
        /// <param name="price">Prijs van het huis als int</param>
        /// <param name="type">Type van het huis (koop of huur) als string</param>
        /// <returns>Array van huizen</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Huis> GetHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null)
                return NotFound();
            return huis;
        }

        /// <summary>
        /// Geeft de specifieke details voor een huis terug
        /// </summary>
        /// <param name="id">Id van het huis waarvan de details gevraagd worden</param>
        /// <returns>Details van een specifiek huis</returns>
        [HttpGet("GetDetailVoorHuis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Detail> GetDetailVoorHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null) return NotFound();
            Console.WriteLine(huis.Detail);
            return huis.Detail;
        }

        /// <summary>
        /// Geeft de specifieke locatie voor een huis terug
        /// </summary>
        /// <param name="id">Id van het huis waarvan de locatie gevraagd wordt</param>
        /// <returns>Locatie van een specifiek huis</returns>
        [HttpGet("GetLocatieVoorHuis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Locatie> GetLocatieVoorHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null) return NotFound();
            return huis.Locatie;
        }

        /// <summary>
        /// Geeft het immobureau terug van specifiek huis
        /// </summary>
        /// <param name="id">Id van het huis waarvan het immobureau gevraagd wordt</param>
        /// <returns>Immobureau van het huis</returns>
        [HttpGet("GetImmoBureauVoorHuis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ImmoBureau> GetImmoBureauVoorHuis(int id)
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
        [HttpGet("ImmoBureau")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Huis> GetByLocatie(int? Postcode, string Gemeente)
        {
            return _huisRepository.GetByLocatie(Postcode, Gemeente);
        }

        /// <summary>
        /// Geeft alle huizen terug die te huren zijn
        /// </summary>
        /// <returns>Array van huizen die te huren zijn</returns>
        [HttpGet("huren")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Huis> GetHuurHuizen()
        {
            return _huisRepository.GetHuurHuizen();
        }

        /// <summary>
        /// Geeft alle huizen terug die te koop zijn
        /// </summary>
        /// <returns>Array van huizen die te koop zijn</returns>
        [HttpGet("kopen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Huis> GetKoopHuizen()
        {
            return _huisRepository.GetKoopHuizen();
        }

        /// <summary>
        /// Geeft alle huizen terug
        /// </summary>
        /// <returns>Array van huizen</returns>
        [HttpGet("huizen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Huis> GetHuizen()
        {
            return _huisRepository.GetHuizen();
        }

        /// <summary>
        /// Geeft alle appartementen terug
        /// </summary>
        /// <returns>Array van Huizen (appartementen)</returns>
        [HttpGet("appartementen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Huis> GetAppartementen()
        {
            return _huisRepository.GetAppartementen();
        }

        /// <summary>
        /// Geeft alle gronden terug
        /// </summary>
        /// <returns>Array van Huizen (gronden)</returns>
        [HttpGet("gronden")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Huis> GetGronden()
        {
            return _huisRepository.GetGronden();
        }

        /// <summary>
        /// Voegt een nieuw huis toe
        /// </summary>
        /// <param name="huisDTO">DTO van huis met info</param>        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Huis> PostHuis(HuisDTO huisDTO)
        {
            Locatie locatie = new Locatie(huisDTO.Locatie.Gemeente, huisDTO.Locatie.Straatnaam, huisDTO.Locatie.Huisnummer, huisDTO.Locatie.Postcode);
            Detail detail = new Detail(huisDTO.Detail.LangeBeschrijving, huisDTO.Detail.BewoonbareOppervlakte, huisDTO.Detail.TotaleOppervlakte, huisDTO.Detail.EPCWaarde, huisDTO.Detail.KadastraalInkomen);

            ImmoBureau immoBureau = _bureauRepository.GetAll().Where(b => b.Naam.Equals(huisDTO.ImmoBureau.Naam)).FirstOrDefault();
            if(immoBureau == null)
            {
                immoBureau = new ImmoBureau(huisDTO.ImmoBureau.Naam);
            }
            
            Huis huis = new Huis(locatie, huisDTO.KorteBeschrijving, huisDTO.Price, detail, huisDTO.Type, huisDTO.Soort, immoBureau);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutHuis(int id, Huis huis)
        {
            if (id != huis.Id)
            {
                return BadRequest();
            }
            _huisRepository.Update(huis);
            _huisRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Verwijdert het huis met id
        /// </summary>
        /// <param name="id">Id van het te verwijderen huis</param>        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null)
            {
                return NotFound();
            }
            _huisRepository.Delete(huis);
            _huisRepository.SaveChanges();
            return NoContent();
        }
    }
}