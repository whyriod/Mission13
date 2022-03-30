using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        public BowlersDbContext _context { get; set; }
        public EFBowlersRepository(BowlersDbContext b)
        {
            _context = b;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;
    }
}
