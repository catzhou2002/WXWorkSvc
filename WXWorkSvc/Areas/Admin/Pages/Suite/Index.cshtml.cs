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
    public class IndexModel : PageModel
    {
        private readonly WXWork3rd.Data.WXDbContext _context;

        public IndexModel(WXWork3rd.Data.WXDbContext context)
        {
            _context = context;
        }

        public IList<TSuite> TSuite { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Suites != null)
            {
                TSuite = await _context.Suites.ToListAsync();
            }
        }
    }
}
