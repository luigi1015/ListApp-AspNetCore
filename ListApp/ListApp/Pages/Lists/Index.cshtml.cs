using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ListApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ListApp.Pages.Lists
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ListApp.Models.ListAppContext _context;

        public IndexModel(ListApp.Models.ListAppContext context)
        {
            _context = context;
        }

        public IList<List> List { get;set; }

        public async Task OnGetAsync()
        {
            List = await _context.List.ToListAsync();
        }
    }
}
