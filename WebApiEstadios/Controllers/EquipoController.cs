using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("equipos")]
    public class EquipoController: ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EquipoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipo>>> GetAll()
        {
            return await _context.Equipos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Equipo>>GetById(int id)
        {
            return await _context.Equipos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Equipo equipo)
        {
            var existeEstadio = await _context.Estadios.AnyAsync(x => x.Id == equipo.EstadioId);

            if(!existeEstadio)
            {
                return BadRequest("No existe el estadio.");
            }
            _context.Add(equipo);
            await _context.SaveChangesAsync();//Permite guardar la info en la BD, es un commit después de procesar la info
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Equipo equipo, int id)
        {
            var existeEquipo = await _context.Equipos.AnyAsync(x => x.Id == id);

            if (!existeEquipo)
            {
                return BadRequest("No existe el equipo.");
            }

            if(equipo.Id != id)
            {
                return BadRequest("El id del equipo no coincide con el establecido en la url.");
            }
            _context.Update(equipo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Equipos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontró el registro en la BD");
            }

            //Se instancia un objeto, se le asigna el id y se procesa el obj

            _context.Remove(new Equipo()
            {
                Id = id
            });
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
