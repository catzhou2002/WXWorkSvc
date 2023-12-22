using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WXWork3rd.Data;

namespace WXWork.Areas.Admin.Pages.Suite
{
    public class EditModel : PageModel
    {
        private readonly WXWork3rd.Data.WXDbContext _context;

        public EditModel(WXWork3rd.Data.WXDbContext context)
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

            var tsuite =  await _context.Suites.FirstOrDefaultAsync(m => m.Id == id);
            if (tsuite == null)
            {
                return NotFound();
            }
            TSuite = tsuite;
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

            _context.Attach(TSuite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TSuiteExists(TSuite.Id))
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

        private bool TSuiteExists(string id)
        {
          return (_context.Suites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
