using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ListApp.Pages.Lists
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ListApp.Models.ListAppContext _context;

        public EditModel(ListApp.Models.ListAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List List { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List = await _context.List.FirstOrDefaultAsync(m => m.ID == id);

            if (List == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(List).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(List.ID))
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

        private bool ListExists(int id)
        {
            return _context.List.Any(e => e.ID == id);
        }
    }
}
