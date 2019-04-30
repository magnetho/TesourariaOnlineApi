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
    public class CedulaController : ControllerBase
    {
        private readonly TesourariaOnlineContext _context;

        public CedulaController(TesourariaOnlineContext context)
        {
            _context = context;
        }

        // GET: api/Cedula
        [HttpGet]
        public IEnumerable<Cedula> GetCedula()
        {
            return _context.Cedula;
        }

        // GET: api/Cedula/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCedula([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cedula = await _context.Cedula.FindAsync(id);

            if (cedula == null)
            {
                return NotFound();
            }

            return Ok(cedula);
        }

        // PUT: api/Cedula/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCedula([FromRoute] int id, [FromBody] Cedula cedula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cedula.CedulaId)
            {
                return BadRequest();
            }

            _context.Entry(cedula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CedulaExists(id))
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

        // POST: api/Cedula
        [HttpPost]
        public async Task<IActionResult> PostCedula([FromBody] Cedula cedula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cedula.Add(cedula);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CedulaExists(cedula.CedulaId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCedula", new { id = cedula.CedulaId }, cedula);
        }

        // DELETE: api/Cedula/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCedula([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cedula = await _context.Cedula.FindAsync(id);
            if (cedula == null)
            {
                return NotFound();
            }

            _context.Cedula.Remove(cedula);
            await _context.SaveChangesAsync();

            return Ok(cedula);
        }

        private bool CedulaExists(int id)
        {
            return _context.Cedula.Any(e => e.CedulaId == id);
        }
    }
}