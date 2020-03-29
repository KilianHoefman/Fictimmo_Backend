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
        /// Geef alle huizen
        /// </summary>
        /// <param name="price"></param>
        /// <param name="type"></param>
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
        /// <param name="id"></param>
        /// <returns>Het huis</returns>
        [HttpGet("{id}")]
        public ActionResult<Huis> GetHuis(int id)
        {
            Huis huis = _huisRepository.GetById(id);
            if (huis == null)
                return NotFound();
            return huis;
        }

        [HttpGet("immoBureau")]
        public IEnumerable<Huis> GetByImmoBureau(string Naam)
        {
            return _huisRepository.GetByImmoBureau(Naam);
        }

        [HttpGet("Locatie")]
        public IEnumerable<Huis> GetByLocatie(int? Postcode, string Gemeente)
        {
            return _huisRepository.GetByLocatie(Postcode, Gemeente);
        }


        /*[HttpPost]
        public ActionResult<Huis> PostHuis(HuisDTO huis)
        {
        }*/
    }
}