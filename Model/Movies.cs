using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Model
{
    internal class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Movies() { }
        public Movies(int movieId, string movieName, int year, string director)
        {
            MovieId = movieId;
            MovieName = movieName;
            Director = director;
            Year = year;
        }
    }
}
