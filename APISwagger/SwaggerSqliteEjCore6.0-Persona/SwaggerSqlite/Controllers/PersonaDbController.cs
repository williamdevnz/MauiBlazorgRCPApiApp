using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaggerSqlite.Data;
using SwaggerSqlite.Domain;

namespace SwaggerSqlite.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaDbController : ControllerBase
    {
        private readonly TodoContext<PersonaDb> _context;

        public PersonaDbController(TodoContext<PersonaDb> context)
        {
            _context = context;
        }

       

        // GET: api/PersonaDb
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDb>>> GetPersonaDb()
        {
            var PersonaDb = await _context.GetAllAsync();
            return Ok(PersonaDb);
        }

        // GET: api/PersonaDb/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDb>> GetEmpleado(int id)
        {
            var empleado = await _context.GetByIdAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // POST: api/PersonaDb
        [HttpPost]
        public async Task<ActionResult<PersonaDb>> PostEmpleado(PersonaDb empleado)
        {
            await _context.AddAsync(empleado);
            await _context.SaveChangesAsync();
            //var personas = await _context.GetAllAsync();
            //var id = personas.OrderByDescending(e => e.idPersona).FirstOrDefault();
            return CreatedAtAction("GetEmpleado", new { id = empleado.idPersona }, empleado);
        }

        // PUT: api/PersonaDb/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, PersonaDb empleado)
        {
            if (id != empleado.idPersona)
            {
                return BadRequest();
            }           
            try
            {
                _context.Update(empleado);
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

        // DELETE: api/PersonaDb/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                var empleado = await _context.GetByIdAsync(id);
                if (empleado == null)
                {
                    return NotFound();
                }

                _context.Delete(empleado);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw ;
            }

            return NoContent();
        }

            [HttpGet("Exists/{id}")]
        public async Task<bool> EmpleadoExistsAsync(int id)
        {
            //return _context.FindBy(e => e.idPersona == id) != null;
            var empleado = await _context.GetByIdAsync(id);
            return empleado != null;
        }
    }

}
