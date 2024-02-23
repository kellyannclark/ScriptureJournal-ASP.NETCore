using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.ScriptureJournal
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public string CurrentFilter { get; set; }

        public string ScriptureBookSort { get; set; }

        // Add the DateSort property
        public string DateSort { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            CurrentFilter = searchString;
            ScriptureBookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Scripture> scripturesQuery = from s in _context.Scriptures
                                                    select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                scripturesQuery = scripturesQuery.Where(s => s.Book.Contains(searchString)
                                                || s.BookAndChapter.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "book_desc":
                    scripturesQuery = scripturesQuery.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    scripturesQuery = scripturesQuery.OrderBy(s => s.DateAdded);
                    break;
                case "date_desc":
                    scripturesQuery = scripturesQuery.OrderByDescending(s => s.DateAdded);
                    break;
                default:
                    scripturesQuery = scripturesQuery.OrderBy(s => s.Book);
                    break;
            }

            Scripture = await scripturesQuery.ToListAsync();
        }
    }

}
