using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace dotnet.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Product> Products { get; set; }
        public SelectList ds { get; set; }
        public string loaidachon { get; set; }
        public string SearchString { get; set; }
    }
}