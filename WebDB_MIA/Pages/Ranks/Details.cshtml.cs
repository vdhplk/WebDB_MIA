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
    public class DetailsModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public DetailsModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

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
    }
}
