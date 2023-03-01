using Microsoft.AspNetCore.Mvc;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("api/estadios")]
    public class EstadiosController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Estadio>> Get()
        {
            return new List<Estadio>()
            {
                new Estadio() { Id = 1, Nombre = "Azteca"},
                new Estadio() { Id =2, Nombre = "UNI"}
            };
        }

    }
}
