using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;
using Shop.Services;
using System.Threading.Tasks;

namespace Shop.Controllers {

        [Route("v1/account")]
        public class HomeController : ControllerBase {


            [HttpPost]
            [Route("login")]
            [AllowAnonymous]
            public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model) {
                var user = UserRepository.Get(model.Username, model.Password);

                if (user == null)
                    return NotFound(new { message = "Usuario ou senha inválidos" });

                var token = TokenService.GenerateToken(user);
                user.Password = "";
                return new {
                    user = user,
                    token = token
                };
            }

            [HttpGet]
            [Route("anonymous")]
            [AllowAnonymous]
            public string Anonymous() => "Anônimo";

            [HttpGet]
            [Route("authenticated")]
            [Authorize]
            public string authenticated() => string.Format("Autenticado - {0}", User.Identity.Name);

            [HttpGet]
            [Route("employee")]
            [Authorize(Roles = "employee, manager")]
            public string Employee() => "Funcionario";

            [HttpGet]
            [Route("manager")]
            [Authorize(Roles = "manager")]
            public string Manager() => "Gerente";
        }
}
