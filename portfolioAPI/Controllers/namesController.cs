using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolioAPI.Models;

namespace portfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class namesController : ControllerBase
    {
        private readonly nameCont _context;

        public namesController(nameCont context)
        {
            _context = context;
        }

        // GET: api/names
        [HttpGet]
        public async Task<ActionResult<IEnumerable<name>>> Getname()
        {
          if (_context.name == null)
          {
              return NotFound();
          }
            return await _context.name.ToListAsync();
        }

        // GET: api/names/5
        [HttpGet("{id}")]
        public async Task<ActionResult<name>> Getname(int id)
        {
          if (_context.name == null)
          {
              return NotFound();
          }
            var name = await _context.name.FindAsync(id);

            if (name == null)
            {
                return NotFound();
            }

            return name;
        }

        // PUT: api/names/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putname(int id, name name)
        {
            if (id != name.Id)
            {
                return BadRequest();
            }

            _context.Entry(name).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nameExists(id))
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

        // POST: api/names
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<name>> Postname(name name)
        {
          if (_context.name == null)
          {
              return Problem("Entity set 'nameCont.name'  is null.");
          }
            _context.name.Add(name);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getname", new { id = name.Id }, name);
        }

        // DELETE: api/names/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletename(int id)
        {
            if (_context.name == null)
            {
                return NotFound();
            }
            var name = await _context.name.FindAsync(id);
            if (name == null)
            {
                return NotFound();
            }

            _context.name.Remove(name);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool nameExists(int id)
        {
            return (_context.name?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
