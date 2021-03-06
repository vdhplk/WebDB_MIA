﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDB_MIA.Data;
using WebDB_MIA.Models;

namespace WebDB_MIA.Pages.TypesCrimes
{
    public class EditModel : PageModel
    {
        private readonly WebDB_MIA.Data.WebDB_MIAContext _context;

        public EditModel(WebDB_MIA.Data.WebDB_MIAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeCrime TypeCrime { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeCrime = await _context.TypeCrime.FirstOrDefaultAsync(m => m.ID == id);

            if (TypeCrime == null)
            {
                return NotFound();
            }
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

            _context.Attach(TypeCrime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCrimeExists(TypeCrime.ID))
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

        private bool TypeCrimeExists(long id)
        {
            return _context.TypeCrime.Any(e => e.ID == id);
        }
    }
}
