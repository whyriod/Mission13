using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using Mission13.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Components
{
    public class BowlerFilterViewComponent : ViewComponent
    {
        private IBowlersRepository _repo { get; set; }

        public BowlerFilterViewComponent(IBowlersRepository b)
        {
            _repo = b;
        }

        public IViewComponentResult Invoke()
        {
            var types = _repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
