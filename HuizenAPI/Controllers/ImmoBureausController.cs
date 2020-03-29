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
    public class ImmoBureausController : ControllerBase
    {
        private readonly IImmoBureauRepository _immoBureausRepository;

        public ImmoBureausController(IImmoBureauRepository context)
        {
            _immoBureausRepository = context;
        }

        [HttpGet]
        public IEnumerable<ImmoBureau> GetImmoBureaus(string naam)
        {
            if (string.IsNullOrEmpty(naam))
                return _immoBureausRepository.GetAll();
            return _immoBureausRepository.GetBy(naam);
        }

        [HttpGet("{id}")]
        public ActionResult<ImmoBureau> GetImmoBureau(int id)
        {
            ImmoBureau immoBureau = _immoBureausRepository.GetById(id);
            if (immoBureau == null) return NotFound();
            return immoBureau;
        }

        [HttpPost]
        public ActionResult<ImmoBureau> PostImmoBureau(ImmoBureauDTO immoBureauDTO)
        {
            ImmoBureau immoBureauToCreate = new ImmoBureau(immoBureauDTO.Naam);
            _immoBureausRepository.Add(immoBureauToCreate);
            _immoBureausRepository.SaveChanges();

            return CreatedAtAction(nameof(GetImmoBureau), new { id = immoBureauToCreate.ImmoBureauId }, immoBureauToCreate);
        }

        [HttpPut("{id}")]
        public IActionResult PutImmoBureau(int id, ImmoBureau immoBureau)
        {
            if(id != immoBureau.ImmoBureauId)
            {
                return BadRequest();
            }
            _immoBureausRepository.Update(immoBureau);
            _immoBureausRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImmoBureau(int id)
        {
            ImmoBureau immoBureau = _immoBureausRepository.GetById(id);
            if (immoBureau == null) return NotFound();
            _immoBureausRepository.Delete(immoBureau);
            _immoBureausRepository.SaveChanges();
            return NoContent();
        }

        /*[HttpPost("{id}")]
        public ActionResult<Huis> PostHuis(int id, HuisDTO huisDTO)
        {
            ImmoBureau immo = _immoBureausRepository.GetById(id);
            if (immo == null) return NotFound();
            if(!_immoBureausRepository.TryGetImmoBureau(id, out var immoBureau))
            {
                return NotFound();
            }
            Locatie locatie = new Locatie(huisDTO.LocatieDTO.Gemeente, huisDTO.LocatieDTO.Straatnaam, huisDTO.LocatieDTO.Huisnummer, huisDTO.LocatieDTO.Postcode);
            Detail detail = new Detail(huisDTO.DetailDTO.LangeBeschrijving, huisDTO.DetailDTO.BewoonbareOppervlakte, huisDTO.DetailDTO.TotaleOppervlakte, huisDTO.DetailDTO.EPCWaarde, huisDTO.DetailDTO.KadastraalInkomen);
            var huisToCreate = new Huis(locatie, huisDTO.KorteBeschrijving, huisDTO.Price, detail, huisDTO.Type, immo);
            immoBureau.AddHuis(huisToCreate);
            _immoBureausRepository.SaveChanges();

            return CreatedAtAction("GetHuis", new { id = immoBureau.ImmoBureauId, huisId = huisToCreate.Id }, huisToCreate);
        }*/
    }
}