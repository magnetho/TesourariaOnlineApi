using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesourariaOnline.Models;
using static System.Net.WebRequestMethods;
using Microsoft.EntityFrameworkCore;

namespace TesourariaOnline.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly TesourariaOnlineContext _context;

        public LoginController(TesourariaOnlineContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioResult = await _context.Usuario.FirstOrDefaultAsync(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);

            if (usuarioResult != null)
                return Ok(usuarioResult);
            else
                return NotFound();
        }
    }
}