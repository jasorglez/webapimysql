using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mysqlWebApi.Services;
using mysqlWebApi.Models;

namespace mysqlWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUsuariosService UsuariosService;
        public UserController(IUsuariosService service) 
        {
            UsuariosService = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(UsuariosService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuarios usuarios)
        {
            UsuariosService.Save(usuarios);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Usuarios usuarios)
        {
            UsuariosService.Update(id,usuarios);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            UsuariosService.Delete(id);
            return Ok();
        }

    }
}
