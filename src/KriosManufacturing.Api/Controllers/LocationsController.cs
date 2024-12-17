namespace KriosManufacturing.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationsController(AppDbContext context) : ControllerBase
    {
        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await context.Locations.ToListAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{locationId:long}")]
        public async Task<ActionResult<Location>> GetLocation(long locationId)
        {
            var location = await context.Locations.FindAsync(locationId);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(long id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            context.Entry(location).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            context.Locations.Add(location);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteLocation(long locationId)
        {
            var location = await context.Locations.FindAsync(locationId);
            if (location == null)
            {
                return NotFound();
            }

            context.Locations.Remove(location);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(long id)
        {
            return context.Locations.Any(e => e.Id == id);
        }
    }
