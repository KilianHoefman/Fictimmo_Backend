using HuizenAPI.DTOs;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HuizenAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Detail> GetDetailVoorHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null) return NotFound();
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
        /// Voegt een nieuw huis toe aan een immobureau
        /// </summary>
        /// <param name="huisDTO">DTO van huis met info</param>        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Huis> PostHuis(HuisDTO huisDTO)
        {
            Locatie locatie = new Locatie(huisDTO.LocatieDTO.Gemeente, huisDTO.LocatieDTO.Straatnaam, huisDTO.LocatieDTO.Huisnummer, huisDTO.LocatieDTO.Postcode);
            Detail detail = new Detail(huisDTO.DetailDTO.LangeBeschrijving, huisDTO.DetailDTO.BewoonbareOppervlakte, huisDTO.DetailDTO.TotaleOppervlakte, huisDTO.DetailDTO.EPCWaarde, huisDTO.DetailDTO.KadastraalInkomen);
            ImmoBureau immoBureau = new ImmoBureau(huisDTO.ImmoBureauDTO.Naam);
            Huis huis = new Huis(locatie, huisDTO.KorteBeschrijving, huisDTO.Price, detail, huisDTO.Type, immoBureau);
            immoBureau.AddHuis(huis);
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
            if(id != huis.Id)
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