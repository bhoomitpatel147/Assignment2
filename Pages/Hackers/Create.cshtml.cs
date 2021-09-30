using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hacker.Models;

namespace HackerData.Pages.Hackers
{
    public class CreateModel : PageModel
    {
        private readonly HackersHackerPagesContext _context;

        public CreateModel(HackersHackerPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HackerDetails HackerDetails { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HackerDetails.Add(HackerDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
