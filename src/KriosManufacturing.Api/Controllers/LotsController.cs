namespace KriosManufacturing.Api.Controllers;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;

[Route("api/[controller]")]
[ApiController]
public class LotsController(AppDbContext context) : ControllerBase
{
    // GET: api/Lots
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lot>>> GetLots()
    {
        return await context.Lots.ToListAsync();
    }

    // GET: api/Lots/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Lot>> GetLot(long id)
    {
        var lot = await context.Lots.FindAsync(id);

        if (lot == null)
        {
            return NotFound();
        }

        return lot;
    }

    // PUT: api/Lots/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLot(long id, Lot lot)
    {
        if (id != lot.Id)
        {
            return BadRequest();
        }

        var item = lot.Item;
        item.Lots.Add(lot);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LotExists(id))
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

    // POST: api/Lots
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Lot>> PostLot(Lot lot)
    {
        var receivedItem = lot.Item;
        var item = await context.Items.FindAsync(receivedItem.Id);
        if (item is null)
        {
            return NotFound();
        }

        lot.Item = item;

        context.Lots.Add(lot);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetLot", new { id = lot.Id }, lot);
    }

    // DELETE: api/Lots/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLot(long id)
    {
        var lot = await context.Lots.FindAsync(id);
        if (lot == null)
        {
            return NotFound();
        }

        context.Lots.Remove(lot);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool LotExists(long id)
    {
        return context.Lots.Any(e => e.Id == id);
    }
}