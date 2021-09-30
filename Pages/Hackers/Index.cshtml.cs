using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hacker.Models;

namespace HackerData.Pages.Hackers
{
    public class IndexModel : PageModel
    {
        private readonly HackersHackerPagesContext _context;

        public IndexModel(HackersHackerPagesContext context)
        {
            _context = context;
        }

        public IList<HackerDetails> HackerDetails { get;set; }

        public async Task OnGetAsync()
        {
            HackerDetails = await _context.HackerDetails.ToListAsync();
        }
    }
}
