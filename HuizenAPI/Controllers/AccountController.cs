using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HuizenAPI.DTOs;
using HuizenAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web4Api.Models;

namespace HuizenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager; 
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly IKlantRepository _klantRepository; 
        private readonly IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IKlantRepository klantRepository, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _klantRepository = klantRepository;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false); if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token); //returns only the token 
                }
            }
            return BadRequest();
        }

        private String GetToken(IdentityUser user)
        {      // Create the token
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName) };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); var token = new JwtSecurityToken(
                    null, null, claims,
                    expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
                return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<String>> Register(RegisterDTO model)
        {
            IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
            ImmoBureau immoBureau = new ImmoBureau(model.ImmoBureau.Naam);
            Klant klant = new Klant { Achternaam = model.Achternaam, GeboorteDatum = model.GeboorteDatum, Email = model.Email, TelefoonNummer = model.TelefoonNummer, ImmoBureau = immoBureau};
            var result = await _userManager.CreateAsync(user, model.Password); 
            if (result.Succeeded)
            {
                _klantRepository.Add(klant); 
                _klantRepository.SaveChanges(); 
                string token = GetToken(user); return Created("", token);
            }
            return BadRequest(); 
        }
    }
}