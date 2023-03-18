using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRM.Data;
using CRM.Models;

namespace CRM.Pages.Salespersons
{
    public class CreateModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public CreateModel(CRM.Data.CRMContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Salesperson Salesperson { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Salesperson == null || Salesperson == null)
            {
                return Page();
            }

            _context.Salesperson.Add(Salesperson);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
