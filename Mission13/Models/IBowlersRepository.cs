﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void SaveBowler();
        public void CreateBowler(Bowler b);
        public void DeleteBowler(Bowler b);
        public void EditBowler(Bowler b);
    }
}
