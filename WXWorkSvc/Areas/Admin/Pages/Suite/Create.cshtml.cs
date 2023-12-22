using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WXWork3rd.Data;

namespace WXWork.Areas.Admin.Pages.Suite
{
    public class CreateModel : PageModel
    {
        private readonly WXWork3rd.Data.WXDbContext _context;

        public CreateModel(WXWork3rd.Data.WXDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TSuite TSuite { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Suites == null || TSuite == null)
            {
                return Page();
            }

            _context.Suites.Add(TSuite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
