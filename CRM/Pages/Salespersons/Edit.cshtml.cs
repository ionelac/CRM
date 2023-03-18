using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Data;
using CRM.Models;

namespace CRM.Pages.Salespersons
{
    public class EditModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public EditModel(CRM.Data.CRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Salesperson Salesperson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Salesperson == null)
            {
                return NotFound();
            }

            var salesperson =  await _context.Salesperson.FirstOrDefaultAsync(m => m.ID == id);
            if (salesperson == null)
            {
                return NotFound();
            }
            Salesperson = salesperson;
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

            _context.Attach(Salesperson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalespersonExists(Salesperson.ID))
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

        private bool SalespersonExists(int id)
        {
          return (_context.Salesperson?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
