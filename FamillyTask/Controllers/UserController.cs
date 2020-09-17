using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

                UserModel resultModel = new UserModel()
                {
                    Id = DbModel.Id,
                    DateNaissance = DbModel.DateNaissance,
                    Login = DbModel.Login,
                    Nom = DbModel.Nom,
                    Prenom = DbModel.Prenom
                };

                resultModel.Token = this.CreateToken(model);

                result = this.Ok(resultModel);
            }

            return result;
        }


        private string CreateToken(LoginModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(this._configuration["jwt:issuer"],
                                             this._configuration["jwt:issuer"],
                                             expires: DateTime.Now.AddMinutes(30),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
