using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Models
{
    public interface IMovieHeader
    {
        string Title { get; }
        string PosterPath { get; }
        int ID { get; }
    }
}
