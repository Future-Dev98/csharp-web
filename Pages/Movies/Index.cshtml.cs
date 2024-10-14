using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPnetcoreapp.Data;
using ASPnetcoreapp.Models;

namespace ASPnetcoreapp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ASPnetcoreapp.Data.ASPnetcoreappContext _context;

        public IndexModel(ASPnetcoreapp.Data.ASPnetcoreappContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
