using AplicacaoEFMysql.DBContexts;
using AplicacaoEFMysql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AplicacaoEFMysql.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ShortURLsController : ControllerBase
    {
        private static List<int> lstNumeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        private static List<char> lstCaracteres = new List<char>()
                                                                    {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                                                                    'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
                                                                    'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                                                                    'Q', 'R', 'S',  'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '_'};

        internal static string GenerateShortURL(int tamanho = 11)
        {
            string URL = "";
            Random rand = new Random();
            for (int i = 0; i < tamanho; i++)
            {
                int random = rand.Next(0, 3);
                if (random == 1)
                {
                    random = rand.Next(0, lstNumeros.Count);
                    URL += lstNumeros[random].ToString();
                }
                else
                {
                    random = rand.Next(0, lstCaracteres.Count);
                    URL += lstCaracteres[random].ToString();
                }
            }
            return URL;
        }

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

        // GET: v1/ShortURLs/aeaba921c5404fed9328ce69b9bcde64
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortURL>> GetShortURL(string id) 
        {
            var shortURL = await _context.ShortURLs.FirstOrDefaultAsync(q => q.shortUrl == id);
            if (shortURL == null)
            {
                return NotFound();
            }
            return shortURL;
        }


        // POST: v1/ShortURLs
        [HttpPost]
        public async Task<ActionResult<ShortURL>> PostShortURL(ShortURL shortURL)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(shortURL.shortUrl))
                {
                    shortURL.shortUrl = GenerateShortURL(5);
                    while (await _context.ShortURLs.FirstOrDefaultAsync(q => q.shortUrl == shortURL.shortUrl) != null)
                    {
                        shortURL.shortUrl = GenerateShortURL(5);
                    }
                }
                _context.ShortURLs.Add(shortURL);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetShortURL", new { id = shortURL.id }, shortURL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
