using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamillyTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FamillyTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            IActionResult result = this.Unauthorized();

            if (model != null)
            {
                UserModel resultModel = new UserModel();

                resultModel.Token = this.CreateToken(model);

                result = this.Ok(resultModel);
            }

            return result;
        }
    }
}
