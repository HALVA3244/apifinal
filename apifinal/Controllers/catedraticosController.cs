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
    public class catedraticosController : ControllerBase
    {
        private readonly apifinalContext _context;

        public catedraticosController(apifinalContext context)
        {
            _context = context;
        }

        // GET: api/catedraticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<catedraticos>>> Getcatedraticos()
        {
            return await _context.catedraticos.ToListAsync();
        }

        // GET: api/catedraticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<catedraticos>> Getcatedraticos(int id)
        {
            var catedraticos = await _context.catedraticos.FindAsync(id);

            if (catedraticos == null)
            {
                return NotFound();
            }

            return catedraticos;
        }

        // PUT: api/catedraticos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcatedraticos(int id, catedraticos catedraticos)
        {
            if (id != catedraticos.id)
            {
                return BadRequest();
            }

            _context.Entry(catedraticos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!catedraticosExists(id))
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

        // POST: api/catedraticos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<catedraticos>> Postcatedraticos(catedraticos catedraticos)
        {
            _context.catedraticos.Add(catedraticos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcatedraticos", new { id = catedraticos.id }, catedraticos);
        }

        // DELETE: api/catedraticos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<catedraticos>> Deletecatedraticos(int id)
        {
            var catedraticos = await _context.catedraticos.FindAsync(id);
            if (catedraticos == null)
            {
                return NotFound();
            }

            _context.catedraticos.Remove(catedraticos);
            await _context.SaveChangesAsync();

            return catedraticos;
        }

        private bool catedraticosExists(int id)
        {
            return _context.catedraticos.Any(e => e.id == id);
        }
    }
}
