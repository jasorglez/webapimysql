using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mysqlWebApi.Models;
using mysqlWebApi.Services;

namespace mysqlWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
            protected readonly IBancosService BancosService;
            public BancosController(IBancosService service)
            {
                BancosService = service;
            }

            [HttpGet]
            public ActionResult Get()
            {
                return Ok(BancosService.Get());
            }

            [HttpPost]
            public IActionResult Post([FromBody] Banks bancos)
            {
                BancosService.Save(bancos);
                return Ok();
            }

            [HttpPut]
            public IActionResult Put(int id, [FromBody] Banks bancos)
            {
                BancosService.Update(id, bancos);
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                BancosService.Delete(id);
                return Ok();
            }

        }
    }




