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
    public class WebContentController : ControllerBase
    {
        private readonly CsbcContext _context;

        /// <summary>
        /// WebContentController
        /// </summary>
        /// <param name="context"></param>
        public WebContentController(CsbcContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebContent>>> GetWebContent()
        {
            return await _context.WebContent.ToListAsync();
        }

        // GET: api/WebContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebContent>> GetWebContent(int id)
        {
            var webContent = await _context.WebContent.FindAsync(id);

            if (webContent == null)
            {
                return NotFound();
            }

            return webContent;
        }

        // PUT: api/WebContent/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult>
        PutWebContent(int id, WebContent webContent)
        {
            if (id != webContent.WebContentId)
            {
                return BadRequest();
            }

            _context.Entry(webContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebContentExists(id))
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

        // POST: api/WebContent
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WebContent>>
        PostWebContent(WebContent webContent)
        {
            _context.WebContent.Add (webContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebContent",
            new { id = webContent.WebContentId },
            webContent);
        }

        // DELETE: api/WebContent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebContent>> DeleteWebContent(int id)
        {
            var webContent = await _context.WebContent.FindAsync(id);
            if (webContent == null)
            {
                return NotFound();
            }

            _context.WebContent.Remove (webContent);
            await _context.SaveChangesAsync();

            return webContent;
        }

        private bool WebContentExists(int id)
        {
            return _context.WebContent.Any(e => e.WebContentId == id);
        }
    }
}
