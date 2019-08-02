using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_library.Models
{
    public class SearchViewModel
    {
        public SelectList HeaderElements { get; set; }
        public List<Book> Books { get; set; }

        public string HeaderType { get; set; }

        public string SearchString { get; set; }
    }
}
