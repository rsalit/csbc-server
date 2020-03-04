using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csbc_server.Data;
using csbc_server.Models;

namespace csbc_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebContentTypeController : ControllerBase
    {
        private readonly CsbcContext _context;

        public WebContentTypeController(CsbcContext context)
        {
            _context = context;
        }

        // GET: api/WebContentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebContentType>>> GetWebContentType()
        {
            return await _context.WebContentType.ToListAsync();
        }

        // GET: api/WebContentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebContentType>> GetWebContentType(int id)
        {
            var webContentType = await _context.WebContentType.FindAsync(id);

            if (webContentType == null)
            {
                return NotFound();
            }

            return webContentType;
        }

        // PUT: api/WebContentType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebContentType(int id, WebContentType webContentType)
        {
            if (id != webContentType.WebContentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(webContentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebContentTypeExists(id))
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

        // POST: api/WebContentType
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WebContentType>> PostWebContentType(WebContentType webContentType)
        {
            _context.WebContentType.Add(webContentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebContentType", new { id = webContentType.WebContentTypeId }, webContentType);
        }

        // DELETE: api/WebContentType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebContentType>> DeleteWebContentType(int id)
        {
            var webContentType = await _context.WebContentType.FindAsync(id);
            if (webContentType == null)
            {
                return NotFound();
            }

            _context.WebContentType.Remove(webContentType);
            await _context.SaveChangesAsync();

            return webContentType;
        }

        private bool WebContentTypeExists(int id)
        {
            return _context.WebContentType.Any(e => e.WebContentTypeId == id);
        }
    }
}
