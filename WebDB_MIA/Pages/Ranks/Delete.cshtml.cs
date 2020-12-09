using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDB_MIA.Data;
using WebDB_MIA.Models;

namespace WebDB_MIA.Pages.Ranks
{
    public class DeleteModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public DeleteModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rank Rank { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rank = await _context.Rank.FirstOrDefaultAsync(m => m.ID == id);

            if (Rank == null)
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

            Rank = await _context.Rank.FindAsync(id);

            if (Rank != null)
            {
                _context.Rank.Remove(Rank);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
