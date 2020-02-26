using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk2.Data;
using MegaDesk2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDesk2
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk2.Data.MegaDesk2Context _context;

        public IndexModel(MegaDesk2.Data.MegaDesk2Context context)
        {
            _context = context;
        }

        public IList<Desk> Desk { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Name { get; set; }
        public string CustomerName { get; set; }
        public string DateSort { get; set; }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string DeskName { get; set; }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            DateSort = sortOrder == "DAdded_Asc_Sort" ? "DAdded_Desc_Sort" : "DAdded_Asc_Sort";

            IQueryable<string> nameListQuery = from d in _context.Desk
                                               orderby d.CustomerName
                                               select d.CustomerName;

            CurrentFilter = searchString;

            IQueryable<Desk> nameQuery = from d in _context.Desk select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                nameQuery = nameQuery.Where(d => d.CustomerName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(DeskName))
            {
                nameQuery = nameQuery.Where(x => x.CustomerName == DeskName);
            }

            switch (sortOrder)
            {
                case "Name":
                    nameQuery = nameQuery.OrderByDescending(s => s.CustomerName);
                    break;
                case "DAdded_Asc_Sort":
                    nameQuery = nameQuery.OrderBy(s => s.QuoteDate);
                    break;
                case "DAdded_Desc_Sort":
                    nameQuery = nameQuery.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    nameQuery = nameQuery.OrderBy(s => s.CustomerName);
                    break;
            }
            Name = new SelectList(await nameListQuery.Distinct().ToListAsync());
            Desk = await nameQuery.AsNoTracking().ToListAsync();
        }
    }
}
