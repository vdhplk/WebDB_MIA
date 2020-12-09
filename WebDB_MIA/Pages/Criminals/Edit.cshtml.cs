using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDB_MIA.Data;
using WebDB_MIA.Models;

namespace WebDB_MIA.Pages.Criminals
{
    public class EditModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public EditModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Criminal Criminal { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Criminal = await _context.Criminal
                .Include(c => c.Casualties)
                .Include(c => c.Staff)
                .Include(c => c.TypesCrimes).FirstOrDefaultAsync(m => m.ID == id);

            if (Criminal == null)
            {
                return NotFound();
            }
           ViewData["CasualtiesID"] = new SelectList(_context.Casualtie, "ID", "ID");
           ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "ID", "ID");
           ViewData["TypesCrimesID"] = new SelectList(_context.Set<TypeCrime>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Criminal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriminalExists(Criminal.ID))
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

        private bool CriminalExists(long id)
        {
            return _context.Criminal.Any(e => e.ID == id);
        }
    }
}
