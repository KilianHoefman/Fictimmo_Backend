using HuizenAPI.DTOs;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HuizenAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ImmoBureausController : ControllerBase
    {
        private readonly IImmoBureauRepository _immoBureausRepository;

        public ImmoBureausController(IImmoBureauRepository context)
        {
            _immoBureausRepository = context;
        }

        /// <summary>
        /// Geef immobureaus
        /// </summary>
        /// <returns>Array van immobureaus</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<ImmoBureauDTO> GetImmoBureaus()
        {
            IEnumerable<ImmoBureauDTO> bureaus = _immoBureausRepository.GetAll().ToList().Distinct().Select(bureau => new ImmoBureauDTO
            {
                Naam = bureau.Naam
            });
            return bureaus;
        }

        /// <summary>
        /// Geef immobureau met id
        /// </summary>
        /// <param name="id">Id van het immobureau</param>
        /// <returns>ImmoBureau</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ImmoBureau> GetImmoBureau(int id)
        {
            ImmoBureau immoBureau = _immoBureausRepository.GetById(id);
            if (immoBureau == null) return NotFound();
            return immoBureau;
        }

        /// <summary>
        /// Voegt een nieuw ImmoBureau toe
        /// </summary>
        /// <param name="immoBureauDTO">Nieuw ImmoBureau</param>
        /// <returns>ImmoBureau dat gemaakt werkt</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ImmoBureau> PostImmoBureau(ImmoBureauDTO immoBureauDTO)
        {
            ImmoBureau immoBureauToCreate = new ImmoBureau(immoBureauDTO.Naam);
            _immoBureausRepository.Add(immoBureauToCreate);
            _immoBureausRepository.SaveChanges();

            return CreatedAtAction(nameof(GetImmoBureau), new { id = immoBureauToCreate.ImmoBureauId }, immoBureauToCreate);
        }

        /// <summary>
        /// Wijzigt een ImmoBureau
        /// </summary>
        /// <param name="id">Id van het te wijzigen ImmoBureau</param>
        /// <param name="immoBureau">Gewijzigd ImmoBureau</param>       
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutImmoBureau(int id, ImmoBureau immoBureau)
        {
            if (id != immoBureau.ImmoBureauId)
            {
                return BadRequest();
            }
            _immoBureausRepository.Update(immoBureau);
            _immoBureausRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Verwijdert het ImmoBureau met id
        /// </summary>
        /// <param name="id">Id van het te verwijderen ImmoBureau</param>        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteImmoBureau(int id)
        {
            ImmoBureau immoBureau = _immoBureausRepository.GetById(id);
            if (immoBureau == null) return NotFound();
            _immoBureausRepository.Delete(immoBureau);
            _immoBureausRepository.SaveChanges();
            return NoContent();
        }
    }
}