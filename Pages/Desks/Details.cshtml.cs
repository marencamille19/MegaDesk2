using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk2.Data;
using MegaDesk2.Models;

namespace MegaDesk2
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDesk2.Data.MegaDesk2Context _context;

        public DetailsModel(MegaDesk2.Data.MegaDesk2Context context)
        {
            _context = context;
        }

        public Desk Desk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Desk = await _context.Desk.FirstOrDefaultAsync(m => m.ID == id);

            if (Desk == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
