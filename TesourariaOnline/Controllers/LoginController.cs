using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesourariaOnline.Models;

namespace TesourariaOnline.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly TesourariaOnlineContext _context;
        [HttpGet]
        public IActionResult Login(string userName,string password)
        {
            try
            {
                _context.

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}