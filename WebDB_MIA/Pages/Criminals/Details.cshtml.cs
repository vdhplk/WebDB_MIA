using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDB_MIA.Data;
using WebDB_MIA.Models;

namespace WebDB_MIA.Pages.Criminals
{
    public class DetailsModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public DetailsModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
