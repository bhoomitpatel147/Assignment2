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
    public class DeleteModel : PageModel
    {
        private readonly HackersHackerPagesContext _context;

        public DeleteModel(HackersHackerPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HackerDetails = await _context.HackerDetails.FindAsync(id);

            if (HackerDetails != null)
            {
                _context.HackerDetails.Remove(HackerDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
