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

        public IActionResult Index(string teamName)
        {

            var b = _repo.Bowlers
                    .Where(b => b.Team.TeamName == teamName || teamName == null)
                    .OrderBy(b => b.BowlerFirstName)
                    .ToList();
            return View(b);
        }

        [HttpGet]
        public IActionResult BowlerEntry(int id)
        {
            ViewBag.Team = _repo.Teams
                          .ToList();

            Bowler b;

            if(id == 0)
            {
                int nextId = _repo.Bowlers.Max(x => x.BowlerID) + 1;
                b = new Bowler
                {
                    BowlerID = nextId
                };
            }
            else
            {
                b = _repo.Bowlers.Single((b) => b.BowlerID == id);
            }
            return View(b);
        }

        [HttpPost]
        public IActionResult BowlerEntry(Bowler b)
        {
            if (ModelState.IsValid)
            {
                //Check how many we found
                List<Bowler> check = _repo.Bowlers.Where(x => x.BowlerID == b.BowlerID).ToList();

                //None Found
                if(check.Count < 1)
                {
                    _repo.CreateBowler(b);
                }
                //We are updated
                else
                {
                    _repo.EditBowler(b);
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Team = _repo.Teams
                       .ToList();

                return View(b);
            }
        }

        public IActionResult BowlerDelete(int id)
        {
            Bowler b = _repo.Bowlers.Single(x => x.BowlerID == id);
            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }
}
