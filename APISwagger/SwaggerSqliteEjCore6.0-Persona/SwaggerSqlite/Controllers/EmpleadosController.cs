using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaggerSqlite.Data;
using SwaggerSqlite.Domain;

namespace SwaggerSqlite.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly TodoContext<Empleados> _context;

        public EmpleadosController(TodoContext<Empleados> context)
        {
            _context = context;
        }

       

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
            var empleados = await _context.GetAllAsync();
            return Ok(empleados);
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetEmpleado(int id)
        {
            var empleado = await _context.GetByIdAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // POST: api/Empleados
        [HttpPost]
        public async Task<ActionResult<Empleados>> PostEmpleado(Empleados empleado)
        {
            await _context.AddAsync(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
        }

        // PUT: api/Empleados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleados empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

            _context.Update(empleado);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var empleadoExists = await EmpleadoExistsAsync(id);
                if (!await EmpleadoExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.GetByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Delete(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("Exists/{id}")]
        public async Task<bool> EmpleadoExistsAsync(int id)
        {
            //return _context.FindBy(e => e.IdEmpleado == id) != null;
            var empleado = await _context.GetByIdAsync(id);
            return empleado != null;
        }
    }

}
