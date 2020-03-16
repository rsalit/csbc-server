using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csbc_server.Data;
using csbc_server.Interfaces;
using csbc_server.Models;

namespace csbc_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly CsbcContext _context;

        public ISeasonRepository Seasons { get; set; }

        public SeasonController(CsbcContext context, ISeasonRepository seasons)
        {
            _context = context;
            Seasons = seasons;
        }

        // GET: api/Season
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<List<Season>>> GetSeason() =>
                await Seasons.GetAll(1);

        /// <summary>
        /// GetCurrentSeason - retrieves the current season
        /// </summary>
        /// <param name="id">uses the companyId</param>
        /// <returns></returns>
        [Route("GetCurrentSeason")]
        [HttpGet]
        public async Task<ActionResult<Season>> GetCurrentSeason(int id)
        {
            var season =
                await _context
                    .Season
                    .FirstOrDefaultAsync(n =>
                        (n.CurrentSeason == true) && (n.CompanyID == 1));
            if (season == null)
            {
                return NotFound();
            }

            return season;
        }

        /// <summary>
        /// GetSeason
        /// </summary>
        /// <param name="id">get the called season using the SeasonId</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Season>> GetSeason(int id)
        {
            var season = await _context.Season.FindAsync(id);

            if (season == null)
            {
                return NotFound();
            }

            return season;
        }

        // PUT: api/Season/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeason(int id, Season season)
        {
            if (id != season.SeasonID)
            {
                return BadRequest();
            }

            _context.Entry(season).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(id))
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

        // POST: api/Season
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Season>> PostSeason(Season season)
        {
            _context.Season.Add (season);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeason",
            new { id = season.SeasonID },
            season);
        }

        // DELETE: api/Season/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Season>> DeleteSeason(int id)
        {
            var season = await _context.Season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }

            _context.Season.Remove (season);
            await _context.SaveChangesAsync();

            return season;
        }

        private bool SeasonExists(int id)
        {
            return _context.Season.Any(e => e.SeasonID == id);
        }

        // GET api/<controller>/5

        // public async Task<ActionResult<Season>> Get(int id)
        // {
        //     var season = await _context.Season.FirstOrDefaultAsync(s => s.CompanyID == 1 && s.SeasonID == id);
        //     if (season == null)
        //     {
        //         return NotFound();
        //     }

        //     return season;
        // }
    }
}
