using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        public IBowlersRepository _repo {get;set;}

        public HomeController(IBowlersRepository r)
        {
            _repo = r;
        }

        public IActionResult Index()
        {
            var b = _repo.Bowlers
                   .ToList();
            return View(b);
        }

        public IActionResult BowlerEntry(int id)
        {
            ViewBag.Team = _repo.Teams
                          .ToList();

            Bowler bowler = _repo.Bowlers.Single((b) => b.BowlerID == id);
            return View(bowler);
        }

        public IActionResult BowlerDelete()
        {
            return View("Index");
        }
    }
}
