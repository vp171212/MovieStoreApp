using MovieStore.Model;
using System.Configuration;
using System.Drawing;

namespace MovieStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = ConfigurationManager.AppSettings["movieFile"];
            List<Movies> moviesList = new List<Movies>();
            File.WriteAllText(filePath, string.Empty);
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("Please select an action");
                Console.WriteLine("To Display the movies list: 1 ");
                Console.WriteLine("To add movie : 2");
                Console.WriteLine("To find movie by year: 3");
                Console.WriteLine("To Remove movie by name: 4");
                Console.WriteLine("To clear list: 5");
                Console.WriteLine("To exit: 6");
                char command=(char)Console.Read();
                string name1 = Console.ReadLine();
                switch (command)
                {
                    case '1':
                        DisplayMoviesList(filePath);
                        Console.WriteLine("------------------------------------------------");
                        break;
                    case '2':
                        Console.WriteLine("Enter movie name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter movie Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Movie Year: ");
                        int year = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter movie Director");
                        string director = Console.ReadLine();

                        Movies movies = new Movies(id, name, year, director);

                        moviesList.Add(movies);
                        AddMoviesToList(filePath,moviesList);
                        break;
                    case '3':
                        FindMoviesByYear(moviesList);
                        Console.WriteLine("------------------------------------------------");
                        break;
                    case '4':
                        RemoveMovie(moviesList, filePath);
                        Console.WriteLine("------------------------------------------------");
                        break;
                    case '5':
                        moviesList.Clear();
                        File.WriteAllText(filePath,string.Empty);
                        Console.WriteLine("File is cleared");
                        Console.WriteLine("------------------------------------------------");
                        break;
                    case '6':
                        exit = 1;
                        break;
                }
            }
        }

        private static void RemoveMovie(List<Movies> moviesList, string? filePath)
        {
            Console.WriteLine("Enter the name of movie: ");
            string name = Console.ReadLine();
            Movies movie=moviesList.Find(x => x.MovieName == name);
            if (movie == null)
            { Console.WriteLine("movie not found"); }
            else
            {
                moviesList.Remove(movie);
                Console.WriteLine("Movie is removed");
            }
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (Movies movie1 in moviesList)
                {
                    writer.WriteLine(movie1.MovieName);
                    writer.WriteLine(movie1.MovieId);
                    writer.WriteLine(movie1.Year);
                    writer.WriteLine(movie1.Director);
                }
              
            }
        }

        private static void FindMoviesByYear(List<Movies> moviesList)
        {
            Console.WriteLine("Enter the year of movie");
            int year=Convert.ToInt32(Console.ReadLine());
            Movies movie=moviesList.Find(x => x.Year == year);
            if (movie != null)
            {
                Console.WriteLine(movie.MovieName);
            }
            else 
            {
                Console.WriteLine("No movies exist in that year.");
            }
        }

        private static void AddMoviesToList(string filePath,List<Movies> moviesList)
        {
           
            if (moviesList.Count >= 5)
            {
                Console.WriteLine("List is Full");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (Movies movie in moviesList)
                    {   writer.WriteLine("Movie Details:");
                        writer.WriteLine("Movie Id: "+movie.MovieId);
                        writer.WriteLine("Movie Name: "+movie.MovieName);
                        writer.WriteLine("Release Year: "+movie.Year);
                        writer.WriteLine("Movie Director: "+movie.Director);
                    }
                    Console.WriteLine("Movie added successfully");
                    Console.WriteLine("------------------------------------------------");
                }
            }
        }

        private static void DisplayMoviesList(string filePath)
        {
            if (filePath == null)
            { Console.WriteLine("File is empty"); }
            else
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    Console.WriteLine("List of movies are: ");
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}