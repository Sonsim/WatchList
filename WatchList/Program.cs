namespace WatchList
{
    internal class Program
    {
        static void Main()
        {
            Database MyDatabase = new Database(new List<Movie>(), new List<Shows>());
            char choice = '0';
            while (choice != '8')
            {
                Console.Clear();
                Console.WriteLine("Hva vil du gjøre? \n" +
                                  "1. Legg til film \n" +
                                  "2. Legg til serie \n" +
                                  "3. Slett film \n" +
                                  "4. Slett serie \n" +
                                  "5. Se alle filmer \n" +
                                  "6. Se alle serier \n" +
                                  "7. Endre episoder sett i serie\n" +
                                  "8. Avslutt");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Console.Clear();
                        CreateMovie(MyDatabase);
                        break;
                    case '2':
                        Console.Clear();
                        CreateSeries(MyDatabase);
                        break;
                    case '3':
                        Console.Clear();
                        DeleteMovie(MyDatabase);
                        break;
                    case '4':
                        Console.Clear();
                        DeleteShow(MyDatabase);
                        break;
                    case '5':
                        Console.Clear();
                        MyDatabase.ShowMovies();
                        Console.ReadKey();
                        break;
                    case '6':
                        Console.Clear();
                        MyDatabase.ShowShows();
                        Console.ReadKey();
                        break;
                    case '7':
                        Console.Clear();
                        MyDatabase.ChangeEpisodesAndSeasonsSeen();
                        break;
                    case '8':
                        Console.WriteLine("Trykk en knapp for å avslutte");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Feil kommando, prøv igjen");
                        break;

                }
            }
        }

        public static void CreateMovie(Database database)
        {
            Console.WriteLine("Hva heter filmen?");
            var name = Console.ReadLine();
            Console.WriteLine("På en skala fra 1-10, hvor mye vil du se den?");
            var prior = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor kan man se filmen?");
            var where = Console.ReadLine();
            Console.WriteLine("Har du sett den før? Y/N");
            var seen = Console.ReadLine();
            bool watch;
            if (seen.ToLower() == "y")
            {
                watch = true;
            }
            else { watch = false; }

            Console.WriteLine("Hvilken sjanger er filmen?");
            var genre = Console.ReadLine();
            Console.WriteLine("Hvis det er en serie, hvor mange filmer er det i serien?");
            var number = Convert.ToInt32(Console.ReadLine());

            var newMovie = new Movie(name, prior, where, watch, genre, number);
            database.AddMovie(newMovie);
        }

        public static void CreateSeries(Database database)
        {
            Console.WriteLine("Hva heter serien?");
            var name = Console.ReadLine();
            Console.WriteLine("På en skala fra 1-10, hvor mye vil du se den?");
            var prior = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor kan man se serien?");
            var where = Console.ReadLine();
            Console.WriteLine("Har du sett den før? Y/N");
            var seen = Console.ReadLine();
            bool watch;
            if (seen.ToLower() == "y")
            {
                watch = true;
            }
            else { watch = false; }

            Console.WriteLine("Hvilken sjanger er serien?");
            var genre = Console.ReadLine();
            Console.WriteLine("Hvor mange episoder er det i serien?");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hvor mange sesonger er det?");
            var number2 = Convert.ToInt32(Console.ReadLine());

            var newShow = new Shows(name, prior, where, watch, genre, number, number2);
            database.AddShow(newShow);
        }

        public static void DeleteMovie(Database database)
        {
            Console.WriteLine("Skriv navnet på filmen du ønsker å slette");
            foreach (var movies in database.GetMovies())
            {
                Console.WriteLine($"- {movies.Name}");
            }
            var movie = Console.ReadLine();

            foreach (Movie film in database.GetMovies().ToList())
            {
                if (movie.ToLower() == film.Name.ToLower())
                {
                    database.RemoveMovie(film);
                }
            }
        }

        public static void DeleteShow(Database database)
        {
            Console.WriteLine("Skriv navnet på serien du ønsker å slette");
            foreach (var shows in database.GetShows())
            {
                Console.WriteLine($"- {shows.Name}");
            }
            var show = Console.ReadLine();
            foreach (Shows series in database.GetShows().ToList())
            {
                if (show.ToLower() == series.Name.ToLower())
                {
                    database.RemoveShow(series);
                }
            }
        }

        
       
    }
}