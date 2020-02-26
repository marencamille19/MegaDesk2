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
    public class DeleteModel : PageModel
    {
        private readonly MegaDesk2.Data.MegaDesk2Context _context;

        public DeleteModel(MegaDesk2.Data.MegaDesk2Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Desk = await _context.Desk.FindAsync(id);

            if (Desk != null)
            {
                _context.Desk.Remove(Desk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
