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
    public class DetailsModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public DetailsModel(CRM.Data.CRMContext context)
        {
            _context = context;
        }

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
    }
}
