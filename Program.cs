using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Zwolnić klienta z obowiązku "znajomości" konkretnej klasy, której instancja ma być stworzona.	Factory Method
//Stworzyć rodzinę obiektów posiadających określoną cechę wspólną.Abstract Factory
namespace Factory
{
    public class Movies
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Room { get; set; }
        public string Position { get; set; }
        public string Person { get; set; }
    }

   public enum EMovieSelect
    {
        MOVIE_ONE,
        MOVIE_TWO,
        MOVIE_THREE
    }

  public  interface IRegistration
    {
        void Registratrion(Movies movie);
    }


    public class MovieOne : IRegistration
    {
        public void Registratrion(Movies movie)
        {
            Console.WriteLine("Rejestracja na film {0}, kwota {1}, numer sali {2}, miejsce na sali {3}, opis filmu{4}", movie.Name, movie.Price, movie.Room, movie.Position, movie.Description);
        }
    }
    public class MovieTwo : IRegistration
    {
        public void Registratrion(Movies movie)
        {
            Console.WriteLine("Rejestracja na film {0}, kwota {1}, numer sali {2}, miejsce na sali {3}, opis filmu{4}", movie.Name, movie.Price, movie.Room, movie.Position, movie.Description);
        }
    }
    public class MovieThree : IRegistration
    {
        public void Registratrion(Movies movie)
        {
            Console.WriteLine("Rejestracja na film {0}, kwota {1}, numer sali {2}, miejsce na sali {3}, opis filmu{4}", movie.Name, movie.Price, movie.Room, movie.Position, movie.Description);
        }
    }

    public class MovieSelectFactory
    {
        public string SelectRoom()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return randomNumber.ToString();
        }

        public string SelectPosition()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return randomNumber.ToString();
        }

        public virtual IRegistration CreateOrder(EMovieSelect movieSelect, Movies movie)
        {
            IRegistration order = null;
            switch (movieSelect)
            {
                case EMovieSelect.MOVIE_ONE:
                    order = new MovieOne();
                    movie.Price = 20;
                    movie.Description = "Film przygodowy";
                    movie.Position = SelectPosition();
                    movie.Room = SelectRoom();
                    break;
                case EMovieSelect.MOVIE_TWO:
                    order = new MovieTwo();
                    movie.Price = 20;
                    movie.Description = "Film historyczny";
                    movie.Position = SelectPosition();
                    movie.Room = SelectRoom();
                    break;
                case EMovieSelect.MOVIE_THREE:
                    order = new MovieThree();
                    movie.Price = 20;
                    movie.Description = "Film obyczajowy";
                    movie.Position = SelectPosition();
                    movie.Room = SelectRoom();
                    break;
                default:
                    break;
            }
            return order;
        }
    }

    public class SelectProcess
    {
        IRegistration order = null;
//wybor filmu
        public void SelectFilm(EMovieSelect order, Movies movie)
        {
            MovieSelectFactory factory = new MovieSelectFactory();
            this.order = factory.CreateOrder(order, movie);
            this.order.Registratrion(movie);
        }
    }



    class Program
    {/*
        static void Main(string[] args)
        {
            // Tworzenie instancji klasy w której znajduje się metoda do wyboru
            SelectProcess pre = new SelectProcess();

            Movies movie = new Movies();
            movie.Name = "Batman";
            movie.Person = "Jan Kowalski";

            pre.SelectFilm(EMovieSelect.MOVIE_ONE, movie);
            Console.ReadKey();
            
        }*/
    }

}
