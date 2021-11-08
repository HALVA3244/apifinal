using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apifinal.Data;
using apifinal.models;

namespace apifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cursosController : ControllerBase
    {
        private readonly apifinalContext _context;

        public cursosController(apifinalContext context)
        {
            _context = context;
        }

        // GET: api/cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cursos>>> Getcursos()
        {
            return await _context.cursos.ToListAsync();
        }

        // GET: api/cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cursos>> Getcursos(int id)
        {
            var cursos = await _context.cursos.FindAsync(id);

            if (cursos == null)
            {
                return NotFound();
            }

            return cursos;
        }

        // PUT: api/cursos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcursos(int id, cursos cursos)
        {
            if (id != cursos.id)
            {
                return BadRequest();
            }

            _context.Entry(cursos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursosExists(id))
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

        // POST: api/cursos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<cursos>> Postcursos(cursos cursos)
        {
            _context.cursos.Add(cursos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcursos", new { id = cursos.id }, cursos);
        }

        // DELETE: api/cursos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<cursos>> Deletecursos(int id)
        {
            var cursos = await _context.cursos.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }

            _context.cursos.Remove(cursos);
            await _context.SaveChangesAsync();

            return cursos;
        }

        private bool cursosExists(int id)
        {
            return _context.cursos.Any(e => e.id == id);
        }
    }
}
