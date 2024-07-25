﻿using System;
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
    public class DetailsController : ControllerBase
    {
        private readonly Context _context;

        public DetailsController(Context context)
        {
            _context = context;
        }

        // GET: api/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> Getdetail()
        {
          if (_context.detail == null)
          {
              return NotFound();
          }
            return await _context.detail.ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detail>> GetDetail(int id)
        {
          if (_context.detail == null)
          {
              return NotFound();
          }
            var detail = await _context.detail.FindAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }

        // PUT: api/Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetail(int id, Detail detail)
        {
            if (id != detail.Id)
            {
                return BadRequest();
            }

            _context.Entry(detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(id))
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

        // POST: api/Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Detail>> PostDetail(Detail detail)
        {
          if (_context.detail == null)
          {
              return Problem("Entity set 'Context.detail'  is null.");
          }
            _context.detail.Add(detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetail", new { id = detail.Id }, detail);
        }

        // DELETE: api/Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            if (_context.detail == null)
            {
                return NotFound();
            }
            var detail = await _context.detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            _context.detail.Remove(detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailExists(int id)
        {
            return (_context.detail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
