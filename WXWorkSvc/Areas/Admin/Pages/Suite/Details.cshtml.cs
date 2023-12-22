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
    public class DetailsModel : PageModel
    {
        private readonly WXWork3rd.Data.WXDbContext _context;

        public DetailsModel(WXWork3rd.Data.WXDbContext context)
        {
            _context = context;
        }

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
    }
}
