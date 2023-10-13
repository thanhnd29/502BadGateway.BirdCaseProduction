﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.PartItems
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DetailsModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

      public PartItem PartItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PartItems == null)
            {
                return NotFound();
            }

            var partitem = await _context.PartItems.FirstOrDefaultAsync(m => m.PartItemId == id);
            if (partitem == null)
            {
                return NotFound();
            }
            else 
            {
                PartItem = partitem;
            }
            return Page();
        }
    }
}
