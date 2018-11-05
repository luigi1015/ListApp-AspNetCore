using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ListApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ListApp.Pages.Lists
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ListApp.Models.ListAppContext _context;

        public CreateModel(ListApp.Models.ListAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public List List { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.List.Add(List);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}