using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDB_MIA.Data;
using WebDB_MIA.Models;

namespace WebDB_MIA.Pages.Casualties
{
    public class DeleteModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public DeleteModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Casualtie Casualtie { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Casualtie = await _context.Casualtie.FirstOrDefaultAsync(m => m.ID == id);

            if (Casualtie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Casualtie = await _context.Casualtie.FindAsync(id);

            if (Casualtie != null)
            {
                _context.Casualtie.Remove(Casualtie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
