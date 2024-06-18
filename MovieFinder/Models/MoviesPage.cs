using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Models
{

    public class MoviesPage
    {
        public int page { get; set; }
        public List<MovieHeader> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class MovieHeader : IMovieHeader
    {
        public int id { get; set; }

        public string title { get; set; }

        public string poster_path { get; set; }

        public int ID => id;

        public string Title => title;

        public string PosterPath => poster_path;
    }
}
