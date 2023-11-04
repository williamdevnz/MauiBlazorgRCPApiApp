using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaggerSqlite.Data;
using SwaggerSqlite.Domain;

namespace SwaggerSqlite.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly TodoContext<Departamentos> _context;

        public DepartamentosController(TodoContext<Departamentos> context)
        {
            _context = context;
        }

        // GET: api/Departamentos
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Departamentos>>> GetDepartamentos()
        {
            var departamentos = await _context.GetAllAsync();
            return Ok(departamentos);
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamentos>> GetDepartamento(int id)
        {
            var departamento = await _context.GetByIdAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);
        }

        // POST: api/Departamentos
        [HttpPost]
        public async Task<ActionResult<Departamentos>> PostDepartamento(Departamentos departamento)
        {
            await _context.AddAsync(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamento", new { id = departamento.IdDepto }, departamento);
        }

        // PUT: api/Departamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamentos departamento)
        {
            if (id != departamento.IdDepto)
            {
                return BadRequest();
            }

            _context.Update(departamento);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var departamentoExists = await DepartamentoExistsAsync(id);
                if (!await DepartamentoExistsAsync(id))
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
   







        // DELETE: api/Departamentos/5
                [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var departamento = await _context.GetByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Delete(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Exists/{id}")]
        public async Task<bool> DepartamentoExistsAsync(int id)
        {
            var departamento = await _context.GetByIdAsync(id);
            return departamento != null;
        }
    }
}
