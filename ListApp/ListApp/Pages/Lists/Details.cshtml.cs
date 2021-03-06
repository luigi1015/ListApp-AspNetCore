﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly ListApp.Models.ListAppContext _context;

        public DetailsModel(ListApp.Models.ListAppContext context)
        {
            _context = context;
        }

        public List List { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List = await _context.List.Include("ListItems").FirstOrDefaultAsync(m => m.ID == id);

            if (List == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id != null)
            {
                List = await _context.List.Include("ListItems").FirstOrDefaultAsync(m => m.ID == id);
                ListItem newItem = new ListItem();
                newItem.ListId = id.Value;
                newItem.Name = Request.Form["itemName"];
                _context.List.First(m => m.ID == id).ListItems.Add(newItem);
                await _context.SaveChangesAsync();
            }
            
            return Redirect(String.Format("Details?id={0}", id));
        }
    }
}
