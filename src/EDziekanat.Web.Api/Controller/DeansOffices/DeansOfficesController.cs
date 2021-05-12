using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDziekanat.Core.DeansOffices;
using EDziekanat.EntityFramework;

namespace EDziekanat.Web.Api.Controller.DeansOffices
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeansOfficesController : ControllerBase
    {
        private readonly EDziekanatDbContext _context;

        public DeansOfficesController(EDziekanatDbContext context)
        {
            _context = context;
        }

        // GET: api/DeansOffices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeansOffice>>> GetDeansOffices()
        {
            return await _context.DeansOffices.ToListAsync();
        }

        // GET: api/DeansOffices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeansOffice>> GetDeansOffice(Guid id)
        {
            var deansOffice = await _context.DeansOffices.FindAsync(id);

            if (deansOffice == null)
            {
                return NotFound();
            }

            return deansOffice;
        }

        // PUT: api/DeansOffices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeansOffice(Guid id, DeansOffice deansOffice)
        {
            if (id != deansOffice.Id)
            {
                return BadRequest();
            }

            _context.Entry(deansOffice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeansOfficeExists(id))
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

        // POST: api/DeansOffices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DeansOffice>> PostDeansOffice(DeansOffice deansOffice)
        {
            _context.DeansOffices.Add(deansOffice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeansOffice", new { id = deansOffice.Id }, deansOffice);
        }

        // DELETE: api/DeansOffices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeansOffice>> DeleteDeansOffice(Guid id)
        {
            var deansOffice = await _context.DeansOffices.FindAsync(id);
            if (deansOffice == null)
            {
                return NotFound();
            }

            _context.DeansOffices.Remove(deansOffice);
            await _context.SaveChangesAsync();

            return deansOffice;
        }

        private bool DeansOfficeExists(Guid id)
        {
            return _context.DeansOffices.Any(e => e.Id == id);
        }
    }
}
