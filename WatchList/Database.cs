using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList
{
    internal class Database
    {
        private List<Movie> _movieList;
        private List<Shows> _showList;

        private const string MovieFileName = "movies.json";
        private const string ShowFileName = "shows.json";


        public Database(List<Movie> movieList, List<Shows> showList)
        {
            _movieList = movieList;
            _showList = showList;

            LoadData();
        }

        public void AddMovie(Movie movie)
        {
            _movieList.Add(movie);
            SaveData();
            Console.WriteLine($"{movie.Name} er lagt til i listen med prioritering {movie.Priority}");
        }

        public void RemoveMovie(Movie movie)
        {
            _movieList.Remove(movie);
            Console.WriteLine($"{movie.Name} er nå fjernet fra listen");
        }
        public void AddShow(Shows show) {
            _showList.Add(show);
            SaveData();
            Console.WriteLine($"{show.Name} er lagt til i listen med prioritering {show.Priority}");
        }

        public void RemoveShow(Shows show)
        {
            _showList.Remove(show);
            SaveData();
            Console.WriteLine($"{show.Name} er fjernet fra listen");
        }

        public List<Movie> GetMovies()
        {
            return _movieList;
        }

        public List<Shows> GetShows()
        {
            return _showList;
        }

        public void ShowMovies()
        {
            List<Movie> sortedList = _movieList.OrderBy(o => o.Priority).ToList();

            foreach (var film in sortedList)
            {
                Console.WriteLine($"Navn:               {film.Name} \n" +
                                  $"Sjanger:            {film.Genre} \n" +
                                  $"Prioritet:          {film.Priority} \n" +
                                  $"Hvor:               {film.Where} \n" +
                                  $"Antall filmer:      {film.NumberOfMovies()}");
                if (film.Watched == true)
                {
                    Console.WriteLine("Sett tidligere:     Ja");
                }
                else
                {
                    Console.WriteLine("Sett tidligere:     Nei");
                }
                Console.WriteLine();
            }
        }

        public void ShowShows()
        {
            List<Shows> sortedList = _showList.OrderBy(s => s.Priority).ToList();

            foreach (var series in sortedList)
            {
                Console.WriteLine($"Navn:               {series.Name} \n" +
                                  $"Sjanger:            {series.Genre} \n" +
                                  $"Prioritet:          {series.Priority} \n" +
                                  $"Hvor:               {series.Where} \n" +
                                  $"Antall Episoder:    {series.GetEpisodes()} \n" +
                                  $"Antall sesonger:    {series.GetSeasons()} \n" +
                                  $"Episoder sett:      {series.GetNumberSeen()} \n" +
                                  $"Sesonger sett:      {series.GetSeasonSeen()}");
                if (series.Watched == true)
                {
                    Console.WriteLine("Sett tidligere:     Ja");
                }
                else
                {
                    Console.WriteLine("Sett tidligere:     Nei");
                }
                Console.WriteLine();
            }
        }

        public Movie SelectMovie()
        {
            Console.WriteLine("Hvilken film vil du endre?");
            foreach (var movie in _movieList)
            {
                string text = $"- {movie.Name}";
                Console.WriteLine(text.PadLeft(text.Length + 5));
            }
            var ans = Console.ReadLine();
            foreach (var movie in _movieList.ToList())
            {
                if (movie.Name.ToLower() == ans.ToLower())
                    return movie;
            }

            return null;
        }

        public Shows SelectShow()
        {
            Console.WriteLine("Hvilken serie vil du endre?");
            foreach (var show in _showList)
            {
                string text = $"- {show.Name}";
                Console.WriteLine(text.PadLeft(text.Length +5));
            }
            var ans = Console.ReadLine();
            foreach (var show in _showList.ToList())
            {
                if (ans.ToLower() == show.Name.ToLower())
                {
                    return show;
                }
            }

            return null;
        }

        public void ChangeEpisodesAndSeasonsSeen()
        {
            Shows selected = SelectShow();
            Console.WriteLine("Hvor mange episoder har du sett?");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor mange sesonger har du sett?");
            int number2 = Convert.ToInt32(Console.ReadLine());

            selected.ChangeNumberSeen(number1);
            selected.ChangeSeason(number2);
            Console.WriteLine();
            Console.WriteLine($"{selected.Name} er endret!");
        }
        private void SaveData()
        {
            File.WriteAllText(MovieFileName, JsonConvert.SerializeObject(_movieList));
            File.WriteAllText(ShowFileName, JsonConvert.SerializeObject(_showList));
        }
        private void LoadData()
        {
            try
            {
                if (File.Exists(MovieFileName))
                {
                    var movieData = File.ReadAllText(MovieFileName);
                    
                    _movieList = JsonConvert.DeserializeObject<List<Movie>>(movieData);
                    
                }
                else
                {
                    _movieList = new List<Movie>();
                    
                }

                if (File.Exists(ShowFileName))
                {
                    var showData = File.ReadAllText(ShowFileName);
                    
                    _showList = JsonConvert.DeserializeObject<List<Shows>>(showData);
                   
                }
                else
                {
                    _showList = new List<Shows>();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                // Du kan også legge til ytterligere feilsøkingsinformasjon ved behov
            }
        }
    }
    
    
}
