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

namespace CRM.Pages.Pipelines
{
    public class EditModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public EditModel(CRM.Data.CRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pipeline Pipeline { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pipeline == null)
            {
                return NotFound();
            }

            var pipeline =  await _context.Pipeline.FirstOrDefaultAsync(m => m.ID == id);
            if (pipeline == null)
            {
                return NotFound();
            }
            Pipeline = pipeline;
            ViewData["ContactID"] = new SelectList(_context.Set<Contact>(), "ID", "ContactName");
            ViewData["SalepersonID"] = new SelectList(_context.Set<Salesperson>(), "ID", "FullName");//trebuie sa fie ca in models 
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

            _context.Attach(Pipeline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PipelineExists(Pipeline.ID))
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

        private bool PipelineExists(int id)
        {
          return _context.Pipeline.Any(e => e.ID == id);
        }
    }
}
