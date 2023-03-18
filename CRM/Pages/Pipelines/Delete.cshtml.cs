using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRM.Data;
using CRM.Models;

namespace CRM.Pages.Pipelines
{
    public class DeleteModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public DeleteModel(CRM.Data.CRMContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Pipeline Pipeline { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pipeline == null)
            {
                return NotFound();
            }

            var pipeline = await _context.Pipeline.FirstOrDefaultAsync(m => m.ID == id);

            if (pipeline == null)
            {
                return NotFound();
            }
            else 
            {
                Pipeline = pipeline;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pipeline == null)
            {
                return NotFound();
            }
            var pipeline = await _context.Pipeline.FindAsync(id);

            if (pipeline != null)
            {
                Pipeline = pipeline;
                _context.Pipeline.Remove(Pipeline);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
