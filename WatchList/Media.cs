using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList
{
    abstract class Media
    {
        public string Name;
        public int Priority;
        public string Where;
        public bool Watched;
        public string Genre;

        protected Media(string name, int priority, string where, bool watched, string genre)
        {
            Name = name;
            Priority = priority;
            Where = where;
            Watched = watched;
            Genre = genre;
        }

    }
}
