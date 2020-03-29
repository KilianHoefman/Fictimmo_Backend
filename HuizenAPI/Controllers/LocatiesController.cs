using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuizenAPI.DTOs;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web4Api.Models;

namespace HuizenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatiesController : ControllerBase
    {
        private readonly ILocatieRepository _locatieRepository;

        public LocatiesController(ILocatieRepository context)
        {
            _locatieRepository = context;
        }

        /// <summary>
        /// Geeft locaties terug adhv parameters
        /// </summary>
        /// <param name="gemeente">Gemeente van Locatie als string</param>
        /// <param name="straatnaam">Straatnaam van Locatie als string</param>
        /// <param name="huisnummer">Huisnummer van Locatie als string</param>
        /// <param name="postcode">Postcode van Locatie als int</param>
        /// <returns>Array van Locaties die voldoen aan parameters</returns>
        [HttpGet]
        public IEnumerable<Locatie> GetLocaties(string gemeente = null, string straatnaam = null, string huisnummer = null, int? postcode = null)
        {
            if (string.IsNullOrEmpty(gemeente) && string.IsNullOrEmpty(straatnaam) && string.IsNullOrEmpty(huisnummer) && postcode == null)
                return _locatieRepository.GetAll().OrderBy(l => l.Gemeente);
            return _locatieRepository.GetBy(gemeente, straatnaam, huisnummer, postcode);
        }

        /// <summary>
        /// Geeft locatie terug adhv id van Locatie
        /// </summary>
        /// <param name="id">LocatieId</param>
        /// <returns>Locatie</returns>
        [HttpGet("{id}")]
        public ActionResult<Locatie> GetLocatie(int id)
        {
            Locatie locatie = _locatieRepository.GetById(id);
            if(locatie == null)
            {
                return NotFound();
            }
            return locatie;
        }

        /// <summary>
        /// Voegt een locatie toe
        /// </summary>
        /// <param name="locatieDTO">Nieuwe locatie</param>        
        [HttpPost]
        public ActionResult<Locatie> PostLocatie(LocatieDTO locatieDTO)
        {
            Locatie locatieToCreate = new Locatie(locatieDTO.Gemeente, locatieDTO.Straatnaam, locatieDTO.Huisnummer, locatieDTO.Postcode);
            _locatieRepository.Add(locatieToCreate);
            _locatieRepository.SaveChanges();

            return CreatedAtAction(nameof(GetLocatie), new { id = locatieToCreate.LocatieId }, locatieToCreate);
        }


        /// <summary>
        /// Wijzigt een locatie
        /// </summary>
        /// <param name="id">Id van de te wijzigen locatie</param>
        /// <param name="locatie">Gewijzigde locatie</param>        
        [HttpPut("{id}")]
        public IActionResult PutLocatie(int id, Locatie locatie)
        {
            if (id != locatie.LocatieId)
                return BadRequest();
            _locatieRepository.Update(locatie);
            _locatieRepository.SaveChanges();
            return NoContent();
        }


        /// <summary>
        /// Verwijdert een locatie
        /// </summary>
        /// <param name="id">Id van de te verwijderen locatie</param>        
        [HttpDelete("{id}")]
        public IActionResult DeleteLocatie(int id)
        {
            Locatie locatie = _locatieRepository.GetById(id);
            if (locatie == null)
                return NotFound();
            _locatieRepository.Delete(locatie);
            _locatieRepository.SaveChanges();
            return NoContent();
        }
    }
}