using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WXWork3rd.Data;

namespace WXWork.Areas.Admin.Pages.Suite
{
    public class DeleteModel : PageModel
    {
        private readonly WXWork3rd.Data.WXDbContext _context;

        public DeleteModel(WXWork3rd.Data.WXDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TSuite TSuite { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Suites == null)
            {
                return NotFound();
            }

            var tsuite = await _context.Suites.FirstOrDefaultAsync(m => m.Id == id);

            if (tsuite == null)
            {
                return NotFound();
            }
            else 
            {
                TSuite = tsuite;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Suites == null)
            {
                return NotFound();
            }
            var tsuite = await _context.Suites.FindAsync(id);

            if (tsuite != null)
            {
                TSuite = tsuite;
                _context.Suites.Remove(TSuite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
