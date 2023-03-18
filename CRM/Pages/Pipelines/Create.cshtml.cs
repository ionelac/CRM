using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRM.Data;
using CRM.Models;
using System.Security.Policy;

namespace CRM.Pages.Pipelines
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
            ViewData["ContactID"] = new SelectList(_context.Set<Contact>(), "ID","ContactName");
            ViewData["SalespersonID"] = new SelectList(_context.Set<Salesperson>(), "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Pipeline Pipeline { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pipeline.Add(Pipeline);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
