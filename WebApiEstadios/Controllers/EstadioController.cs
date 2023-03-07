using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("estadios")]
    public class EstadioController: ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        public EstadioController(ApplicationDBContext Context)
        {
            this.dbContext = Context;

        }

        [HttpGet]
        public ActionResult<List<Estadio>> Get()
        {
            return new List<Estadio>()
            {
                new Estadio() { Id = 1, Nombre = "Azteca",  Capacidad = 1500},
                new Estadio() { Id =2, Nombre = "UNI",  Capacidad = 1000}
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(Estadio estadio) 
        {
            dbContext.Add(estadio);
            await dbContext.SaveChangesAsync();//Permite guardar la info en la BD, es un commit después de procesar la info
            return Ok();
        }


        [HttpGet("/lista")] //si se le quita el slash, ahora aparecerá avion. Define que no se necesite pasar por la ruta del controlador
        public async Task<ActionResult<List<Estadio>>> GetAll()
        {
            //Incluir la info de los equipos del estadio
            return await dbContext.Estadios.Include(x => x.Equipos).ToListAsync();
        }


        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Estadio estadio, int id)
        {
            if(estadio.Id != id)
            {

                return BadRequest("El id del estadio no coincidie con el de la url");
            }

            dbContext.Update(estadio);

            await dbContext.SaveChangesAsync();
            return Ok();
               
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Estadios.AnyAsync(x=> x.Id == id);
            if(!exist)
            {   
                return NotFound("No se encontró el registro en la BD");
            }

            //Se instancia un objeto, se le asigna el id y se procesa el obj

            dbContext.Remove(new Estadio()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }

    }
}
