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
    public class IndexModel : PageModel
    {
        private readonly CRM.Data.CRMContext _context;

        public IndexModel(CRM.Data.CRMContext context)
        {
            _context = context;
        }

        public IList<Pipeline> Pipeline { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pipeline != null)
            {
                Pipeline = await _context.Pipeline.Include(b=>b.Contact).Include(c => c.Salesperson).ToListAsync();
            }
        }
    }
}
