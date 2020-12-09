using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebDB_MIA.Data;
using WebDB_MIA.Models;

namespace WebDB_MIA.Pages.Criminals
{
    public class CreateModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public CreateModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CasualtiesID"] = new SelectList(_context.Casualtie, "ID", "ID");
        ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "ID", "ID");
        ViewData["TypesCrimesID"] = new SelectList(_context.Set<TypeCrime>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Criminal Criminal { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Criminal.Add(Criminal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
