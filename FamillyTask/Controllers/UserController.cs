using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FamillyTask.DAL.Interface;
using FamillyTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FamillyTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        private IUsersService _service;
        public UserController(IConfiguration configuration, IUsersService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            IActionResult result = this.Unauthorized();

            if (model != null)
            {
                Users DbModel =  _service.CheckLogin(model.Login, model.Passwd);
                if (DbModel is null) return BadRequest();
                UserModel resultModel = new UserModel()
                {
                    Id = DbModel.Id,
                    DateNaissance = DbModel.DateNaissance,
                    Login = DbModel.Login,
                    Nom = DbModel.Nom,
                    Prenom = DbModel.Prenom
                };

                resultModel.Token = this.CreateToken(resultModel);

                result =  Ok(resultModel);
            }

            return result;
        }


        private string CreateToken(UserModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
           {
                new Claim("UserName", model.Login), 
                new Claim("FirstName",model.Prenom),
                new Claim("LastName",model.Nom),
                new Claim("Id",model.Id.ToString())
            });



            var token = new JwtSecurityToken(this._configuration["jwt:issuer"],
                                             this._configuration["jwt:issuer"],
                                             claims: claimsIdentity.Claims,
                                             expires: DateTime.Now.AddMinutes(30),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
