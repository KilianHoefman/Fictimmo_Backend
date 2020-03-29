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
    public class DetailsController : ControllerBase
    {
        private readonly IDetailRepository _detailRepository;

        public DetailsController(IDetailRepository context)
        {
            _detailRepository = context;
        }

        /// <summary>
        /// Geeft details geordend op id
        /// </summary>
        /// <param name="bewoonbareOppervlakte">bewoonbare oppervlakte als int</param>
        /// <param name="totaleOppervlakte">totale oppervlakte als int</param>
        /// <param name="epcWaarde">epcwaarde als int</param>
        /// <param name="kadastraalInkomen">kadastraal inkomen als int</param>
        /// <returns>array van Details gebaseerd op parameters</returns>
        [HttpGet]
        public IEnumerable<Detail> GetDetails(int? bewoonbareOppervlakte = null, int? totaleOppervlakte = null, int? epcWaarde = null, int? kadastraalInkomen = null)
        {
            if (bewoonbareOppervlakte == null && totaleOppervlakte == null && epcWaarde == null && kadastraalInkomen == null)
                return _detailRepository.GetAll().OrderBy(d => d.DetailID);
            return _detailRepository.GetBy(bewoonbareOppervlakte, totaleOppervlakte, epcWaarde, kadastraalInkomen);
        }

        /// <summary>
        /// Geeft detail op id
        /// </summary>
        /// <param name="id">Id van het detail als int</param>
        /// <returns>Detail</returns>
        [HttpGet("{id}")]
        public ActionResult<Detail> GetDetail(int id)
        {
            Detail detail = _detailRepository.GetById(id);
            if (detail == null)
                return NotFound();
            return detail;
        }

        /// <summary>
        /// Voegt een detail toe
        /// </summary>
        /// <param name="detailDTO">Het nieuwe detail</param>       
        [HttpPost]
        public ActionResult<Detail> PostDetail(DetailDTO detailDTO)
        {
            Detail detailToCreate = new Detail(detailDTO.LangeBeschrijving, detailDTO.BewoonbareOppervlakte, detailDTO.TotaleOppervlakte, detailDTO.EPCWaarde, detailDTO.KadastraalInkomen);
            _detailRepository.Add(detailToCreate);
            _detailRepository.SaveChanges();

            return CreatedAtAction(nameof(GetDetail), new { id = detailToCreate.DetailID }, detailToCreate);
        }

        /// <summary>
        /// Wijzigt een detail
        /// </summary>
        /// <param name="id">Id van het te wijzigen detail</param>
        /// <param name="detail">Het gewijzigd detail</param>        
        [HttpPut("{id}")]
        public IActionResult PutDetail(int id, Detail detail)
        {
            if(id != detail.DetailID)
            {
                return BadRequest();
            }
            _detailRepository.Update(detail);
            _detailRepository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Verwijdert een detail
        /// </summary>
        /// <param name="id">Het id van het te verwijderen detail</param>       
        [HttpDelete("{id}")]
        public IActionResult DeleteDetail(int id)
        {
            Detail detail = _detailRepository.GetById(id);
            if(detail == null)
            {
                return NotFound();
            }
            _detailRepository.Delete(detail);
            _detailRepository.SaveChanges();
            return NoContent();
        }
    }
}