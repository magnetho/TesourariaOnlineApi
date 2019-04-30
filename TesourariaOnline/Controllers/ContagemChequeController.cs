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
    public class ContagemChequeController : ControllerBase
    {
        private readonly TesourariaOnlineContext _context;

        public ContagemChequeController(TesourariaOnlineContext context)
        {
            _context = context;
        }

        // GET: api/ContagemCheque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContagemCheque>>> GetContagemCheque()
        {
            return await _context.ContagemCheque.ToListAsync();
        }

        // GET: api/ContagemCheque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContagemCheque>> GetContagemCheque(int id)
        {
            var contagemCheque = await _context.ContagemCheque.FindAsync(id);

            if (contagemCheque == null)
            {
                return NotFound();
            }

            return contagemCheque;
        }

        // PUT: api/ContagemCheque/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContagemCheque(int id, ContagemCheque contagemCheque)
        {
            if (id != contagemCheque.ContagemChequeId)
            {
                return BadRequest();
            }

            _context.Entry(contagemCheque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContagemChequeExists(id))
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

        // POST: api/ContagemCheque
        [HttpPost]
        public async Task<ActionResult<ContagemCheque>> PostContagemCheque(ContagemCheque contagemCheque)
        {
            _context.ContagemCheque.Add(contagemCheque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContagemCheque", new { id = contagemCheque.ContagemChequeId }, contagemCheque);
        }

        // DELETE: api/ContagemCheque/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContagemCheque>> DeleteContagemCheque(int id)
        {
            var contagemCheque = await _context.ContagemCheque.FindAsync(id);
            if (contagemCheque == null)
            {
                return NotFound();
            }

            _context.ContagemCheque.Remove(contagemCheque);
            await _context.SaveChangesAsync();

            return contagemCheque;
        }

        private bool ContagemChequeExists(int id)
        {
            return _context.ContagemCheque.Any(e => e.ContagemChequeId == id);
        }
    }
}
