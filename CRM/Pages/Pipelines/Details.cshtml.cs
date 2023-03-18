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
    public class DetailsModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public DetailsModel(CRM.Data.CRMContext context)
        {
            _context = context;
        }

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
    }
}
