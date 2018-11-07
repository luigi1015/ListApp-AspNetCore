using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ListApp.Models;

namespace ListApp.Pages.Lists
{
    public class DeleteListItemModel : PageModel
    {
        private readonly ListApp.Models.ListAppContext _context;

        public DeleteListItemModel(ListApp.Models.ListAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ListItem ListItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListItem = await _context.ListItem
                .Include(l => l.List).FirstOrDefaultAsync(m => m.ID == id);

            if (ListItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListItem = await _context.ListItem.FindAsync(id);
            int listId = ListItem.ListId;

            if (ListItem != null)
            {
                _context.ListItem.Remove(ListItem);
                await _context.SaveChangesAsync();
            }

            return Redirect(String.Format("Details?id={0}", listId));
        }
    }
}
