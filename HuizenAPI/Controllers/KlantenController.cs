using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuizenAPI.DTOs;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuizenAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class KlantenController : ControllerBase
    {
        private readonly IKlantRepository _klantenRepository;
        public KlantenController(IKlantRepository context)
        {
            _klantenRepository = context;
        }

        /// <summary>
        /// Geeft klanten adhv parameters
        /// </summary>
        /// <param name="voornaam">Voornaam van de klant als string</param>
        /// <param name="achternaam">Achternaam van de klant als string</param>
        /// <param name="email">Email van de klant als string</param>
        /// <param name="telefoonNummer">Telefoonnummer van de klant als string</param>
        /// <returns>Array van klanten</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IEnumerable<Klant> GetKlanten(string voornaam = null, string achternaam = null, string email = null, string telefoonNummer = null)
        {
            if (string.IsNullOrEmpty(voornaam) && string.IsNullOrEmpty(achternaam) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(telefoonNummer))
                return _klantenRepository.GetAll();
            return _klantenRepository.GetBy(voornaam, achternaam, email, telefoonNummer);
        }

        /// <summary>
        /// Geeft klant terug met id
        /// </summary>
        /// <param name="id">Klantennummer van de gewenste klant</param>
        /// <returns>Klant</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<Klant> GetKlant(int id)
        {
            Klant klant = _klantenRepository.GetById(id);
            if (klant == null) return NotFound();
            return klant;
        }


        /// <summary>
        /// Voegt een nieuwe klant toe
        /// </summary>
        /// <param name="klantDTO">De nieuwe toe te voegen klant</param>
        /// <returns>Gecreëerde Klant</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Klant> PostKlant(KlantDTO klantDTO)
        {
            
            Klant klantToCreate = new Klant(klantDTO.Voornaam, klantDTO.Achternaam, klantDTO.GeboorteDatum, klantDTO.Email, klantDTO.TelefoonNummer, new ImmoBureau(klantDTO.immoBureau.Naam));
            _klantenRepository.Add(klantToCreate);
            _klantenRepository.SaveChanges();

            return CreatedAtAction(nameof(GetKlant), new { id = klantToCreate.KlantenNummer }, klantToCreate);
        }

        /// <summary>
        /// Wijzigt een Klant
        /// </summary>
        /// <param name="id">Klantennummer van de te wijzigen klant</param>
        /// <param name="klant">Gewijzigde klant</param>        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult PutKlant(int id, Klant klant)
        {
            if(id != klant.KlantenNummer)
            {
                return BadRequest();
            }
            _klantenRepository.Update(klant);
            _klantenRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Verwijdert een klant met id
        /// </summary>
        /// <param name="id">Klantennummer van de te verwijderen klant</param>        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKlant(int id)
        {
            Klant klant = _klantenRepository.GetById(id);
            if (klant == null) return NotFound();
            _klantenRepository.Delete(klant);
            _klantenRepository.SaveChanges();
            return NoContent();
        }
    }
}