using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRM.Data;
using CRM.Models;

namespace CRM.Pages.Salespersons
{
    public class DeleteModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public DeleteModel(CRM.Data.CRMContext context)
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

            var salesperson = await _context.Salesperson.FirstOrDefaultAsync(m => m.ID == id);

            if (salesperson == null)
            {
                return NotFound();
            }
            else 
            {
                Salesperson = salesperson;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Salesperson == null)
            {
                return NotFound();
            }
            var salesperson = await _context.Salesperson.FindAsync(id);

            if (salesperson != null)
            {
                Salesperson = salesperson;
                _context.Salesperson.Remove(Salesperson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
