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
    public class reportesController : ControllerBase
    {
        private readonly apifinalContext _context;

        public reportesController(apifinalContext context)
        {
            _context = context;
        }

        // GET: api/reportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<reportes>>> Getreportes()
        {
            return await _context.reportes.ToListAsync();
        }

        // GET: api/reportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<reportes>> Getreportes(int id)
        {
            var reportes = await _context.reportes.FindAsync(id);

            if (reportes == null)
            {
                return NotFound();
            }

            return reportes;
        }

        // PUT: api/reportes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreportes(int id, reportes reportes)
        {
            if (id != reportes.id)
            {
                return BadRequest();
            }

            _context.Entry(reportes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reportesExists(id))
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

        // POST: api/reportes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<reportes>> Postreportes(reportes reportes)
        {
            _context.reportes.Add(reportes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreportes", new { id = reportes.id }, reportes);
        }

        // DELETE: api/reportes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<reportes>> Deletereportes(int id)
        {
            var reportes = await _context.reportes.FindAsync(id);
            if (reportes == null)
            {
                return NotFound();
            }

            _context.reportes.Remove(reportes);
            await _context.SaveChangesAsync();

            return reportes;
        }

        private bool reportesExists(int id)
        {
            return _context.reportes.Any(e => e.id == id);
        }
    }
}
