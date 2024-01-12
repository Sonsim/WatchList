using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WatchList
{
    internal class Shows : Media
    {
        public int _numberOfEpisodes;
        public int _numberOfSeasons;
        public int _episodesSeen;
        public int _seasonWatching;

        public Shows(string name, int priority, string where, bool watched, string genre, int number1, int number2) : base(name, priority, where, watched, genre)
        {
            _numberOfEpisodes = number1;
            _numberOfSeasons = number2;
        }

        public int GetEpisodes()
        {
            return _numberOfEpisodes;
        }

        public int GetSeasons()
        {
            return _numberOfSeasons;
        }

        public int GetNumberSeen()
        {
            return _episodesSeen;
        }

        public void ChangeNumberSeen(int number)
        {
            _episodesSeen = number;
        }

        public int GetSeasonSeen()
        {
            return _seasonWatching;
        }

        public void ChangeSeason(int number)
        {
            _seasonWatching = number;
        }
    }
}
