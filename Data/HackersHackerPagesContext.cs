using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hacker.Models;

    public class HackersHackerPagesContext : DbContext
    {
        public HackersHackerPagesContext (DbContextOptions<HackersHackerPagesContext> options)
            : base(options)
        {
        }

        public DbSet<Hacker.Models.HackerDetails> HackerDetails { get; set; }
    }
