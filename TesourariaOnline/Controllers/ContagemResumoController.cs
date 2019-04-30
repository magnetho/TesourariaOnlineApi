using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesourariaOnline.Models;

namespace TesourariaOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContagemResumoController : ControllerBase
    {
        private readonly TesourariaOnlineContext _context;

        public ContagemResumoController(TesourariaOnlineContext context)
        {
            _context = context;
        }

        // GET: api/ContagemResumo
        [HttpGet]
        public IEnumerable<ContagemResumo> GetContagemResumo()
        {
            return _context.ContagemResumo;
        }

        // GET: api/ContagemResumo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContagemResumo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contagemResumo = await _context.ContagemResumo.FindAsync(id);

            if (contagemResumo == null)
            {
                return NotFound();
            }

            return Ok(contagemResumo);
        }

        // PUT: api/ContagemResumo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContagemResumo([FromRoute] int id, [FromBody] ContagemResumo contagemResumo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contagemResumo.ContagemResumoId)
            {
                return BadRequest();
            }

            _context.Entry(contagemResumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContagemResumoExists(id))
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

        // POST: api/ContagemResumo
        [HttpPost]
        public async Task<IActionResult> PostContagemResumo([FromBody] ContagemResumo contagemResumo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContagemResumo.Add(contagemResumo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContagemResumoExists(contagemResumo.ContagemResumoId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContagemResumo", new { id = contagemResumo.ContagemResumoId }, contagemResumo);
        }

        // DELETE: api/ContagemResumo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContagemResumo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contagemResumo = await _context.ContagemResumo.FindAsync(id);
            if (contagemResumo == null)
            {
                return NotFound();
            }

            _context.ContagemResumo.Remove(contagemResumo);
            await _context.SaveChangesAsync();

            return Ok(contagemResumo);
        }

        private bool ContagemResumoExists(int id)
        {
            return _context.ContagemResumo.Any(e => e.ContagemResumoId == id);
        }
    }
}