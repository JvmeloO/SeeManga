using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SeeManga.Controllers
{
    public class MangasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarManga()
        {
            return View();
        }
    }
}