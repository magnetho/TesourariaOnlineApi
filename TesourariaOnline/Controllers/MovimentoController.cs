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
    public class MovimentoController : ControllerBase
    {
        private readonly TesourariaOnlineContext _context;

        public MovimentoController(TesourariaOnlineContext context)
        {
            _context = context;
        }

        // GET: api/Movimento
        [HttpGet]
        public IEnumerable<Movimento> GetMovimento()
        {
            return _context.Movimento;
        }

        // GET: api/Movimento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovimento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movimento = await _context.Movimento.FindAsync(id);

            if (movimento == null)
            {
                return NotFound();
            }

            return Ok(movimento);
        }

        // PUT: api/Movimento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimento([FromRoute] int id, [FromBody] Movimento movimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movimento.MovimentoId)
            {
                return BadRequest();
            }

            _context.Entry(movimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentoExists(id))
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

        // POST: api/Movimento
        [HttpPost]
        public async Task<IActionResult> PostMovimento([FromBody] Movimento movimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Movimento.Add(movimento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovimentoExists(movimento.MovimentoId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovimento", new { id = movimento.MovimentoId }, movimento);
        }

        // DELETE: api/Movimento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movimento = await _context.Movimento.FindAsync(id);
            if (movimento == null)
            {
                return NotFound();
            }

            _context.Movimento.Remove(movimento);
            await _context.SaveChangesAsync();

            return Ok(movimento);
        }

        private bool MovimentoExists(int id)
        {
            return _context.Movimento.Any(e => e.MovimentoId == id);
        }
    }
}