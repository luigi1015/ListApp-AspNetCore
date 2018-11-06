using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ListApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ListApp.Pages.Lists
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ListApp.Models.ListAppContext _context;
        private UserManager<IdentityUser> _userManager { get; }

        public IndexModel(ListApp.Models.ListAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<List> List { get;set; }

        public async Task OnGetAsync()
        {
            string userId = _userManager.GetUserId(User);
            List = await _context.List.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
