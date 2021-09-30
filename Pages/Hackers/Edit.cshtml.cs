using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hacker.Models;

namespace HackerData.Pages.Hackers
{
    public class EditModel : PageModel
    {
        private readonly HackersHackerPagesContext _context;

        public EditModel(HackersHackerPagesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HackerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HackerDetailsExists(HackerDetails.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HackerDetailsExists(int id)
        {
            return _context.HackerDetails.Any(e => e.ID == id);
        }
    }
}
