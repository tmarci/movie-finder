using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Models
{

    public class Movie
    {
        public List<Genre> genres { get; set; }
        public int id { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public object poster_path { get; set; }
        public DateTime release_date { get; set; }
        public int runtime { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
