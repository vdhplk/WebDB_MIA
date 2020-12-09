using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDB_MIA.Data;
using WebDB_MIA.Models;

namespace WebDB_MIA.Pages.Staffs
{
    public class IndexModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public IndexModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get;set; }

        public async Task OnGetAsync()
        {
            Staff = await _context.Staff
                .Include(s => s.Position)
                .Include(s => s.Rank).ToListAsync();
        }
    }
}
