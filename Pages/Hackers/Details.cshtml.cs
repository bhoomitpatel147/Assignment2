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
    public class DetailsModel : PageModel
    {
        private readonly HackersHackerPagesContext _context;

        public DetailsModel(HackersHackerPagesContext context)
        {
            _context = context;
        }

        public HackerDetails HackerDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HackerDetails = await _context.HackerDetails.FirstOrDefaultAsync(m => m.ID == id);

            if (HackerDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
