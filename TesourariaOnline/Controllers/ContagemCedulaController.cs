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
    public class ContagemCedulaController : ControllerBase
    {
        private readonly TesourariaOnlineContext _context;

        public ContagemCedulaController(TesourariaOnlineContext context)
        {
            _context = context;
        }

        // GET: api/ContagemCedula
        [HttpGet]
        public IEnumerable<ContagemCedula> GetContagemCedula()
        {
            return _context.ContagemCedula;
        }

        // GET: api/ContagemCedula/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContagemCedula([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contagemCedula = await _context.ContagemCedula.FindAsync(id);

            if (contagemCedula == null)
            {
                return NotFound();
            }

            return Ok(contagemCedula);
        }

        // PUT: api/ContagemCedula/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContagemCedula([FromRoute] int id, [FromBody] ContagemCedula contagemCedula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contagemCedula.ContagemCedulaId)
            {
                return BadRequest();
            }

            _context.Entry(contagemCedula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContagemCedulaExists(id))
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

        // POST: api/ContagemCedula
        [HttpPost]
        public async Task<IActionResult> PostContagemCedula([FromBody] ContagemCedula contagemCedula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContagemCedula.Add(contagemCedula);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContagemCedulaExists(contagemCedula.ContagemCedulaId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContagemCedula", new { id = contagemCedula.ContagemCedulaId }, contagemCedula);
        }

        // DELETE: api/ContagemCedula/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContagemCedula([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contagemCedula = await _context.ContagemCedula.FindAsync(id);
            if (contagemCedula == null)
            {
                return NotFound();
            }

            _context.ContagemCedula.Remove(contagemCedula);
            await _context.SaveChangesAsync();

            return Ok(contagemCedula);
        }

        private bool ContagemCedulaExists(int id)
        {
            return _context.ContagemCedula.Any(e => e.ContagemCedulaId == id);
        }
    }
}