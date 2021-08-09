using AplicacaoEFMysql.DBContexts;
using AplicacaoEFMysql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoEFMysql.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ShortURLsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ShortURLsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: v1/ShortURLs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortURL>>> GetShortURLs()
        {
            return await _context.ShortURLs.ToListAsync();
        }

        // GET: v1/ShortURLs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortURL>> GetShortURL(long id)
        {
            var shortURL = await _context.ShortURLs.FindAsync(id);

            if (shortURL == null)
            {
                return NotFound();
            }

            return shortURL;
        }

        // PUT: v1/ShortURLs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortURL(long id, ShortURL shortURL)
        {
            if (id != shortURL.id)
            {
                return BadRequest();
            }

            _context.Entry(shortURL).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortURLExists(id))
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

        // POST: v1/ShortURLs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShortURL>> PostShortURL(ShortURL shortURL)
        {
            _context.ShortURLs.Add(shortURL);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShortURL", new { id = shortURL.id }, shortURL);
        }

        // DELETE: v1/ShortURLs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShortURL>> DeleteShortURL(long id)
        {
            var shortURL = await _context.ShortURLs.FindAsync(id);
            if (shortURL == null)
            {
                return NotFound();
            }

            _context.ShortURLs.Remove(shortURL);
            await _context.SaveChangesAsync();

            return shortURL;
        }

        private bool ShortURLExists(long id)
        {
            return _context.ShortURLs.Any(e => e.id == id);
        }
    }
}
