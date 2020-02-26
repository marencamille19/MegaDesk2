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
    public class IndexModel : PageModel
    {
        private readonly MegaDesk2.Data.MegaDesk2Context _context;

        public IndexModel(MegaDesk2.Data.MegaDesk2Context context)
        {
            _context = context;
        }

        public IList<Desk> Desk { get;set; }

        public async Task OnGetAsync()
        {
            Desk = await _context.Desk.ToListAsync();
        }
    }
}
