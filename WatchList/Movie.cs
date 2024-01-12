using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList
{
    internal class Movie : Media
    {
        public int _numberOfMovies;


        public Movie(string name, int priority, string where, bool watched, string genre, int number) : base(name, priority, where, watched, genre)
        {
            _numberOfMovies = number;
        }

        public int NumberOfMovies()
        {
            return _numberOfMovies;
        }

    }
}
