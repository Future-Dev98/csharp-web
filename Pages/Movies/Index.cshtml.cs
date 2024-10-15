using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)] // liên kết các giá trị biểu mẫu và chuỗi truy vấn có cùng tên với thuộc tính,  [BindProperty(SupportsGet = true)] là bắt buộc để liên kết trên các yêu cầu HTTP GET.
        public string? SearchString { get; set; } // Chứa văn bản người dùng nhập vào hộp văn bản tìm kiếm
        public SelectList? Genres { get; set; } // Chứa danh sách các thể loại. Genrescho phép người dùng chọn một thể loại từ danh sách. SelectListyêu cầuusing Microsoft.AspNetCore.Mvc.Rendering;
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; } // Chứa thể loại cụ thể mà người dùng chọn. Ví dụ: "Western".

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
