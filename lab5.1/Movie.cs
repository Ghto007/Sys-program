using System.Collections.Generic;

namespace lab
{
    public class Movie
    {
        // 4 властивості, одна з яких є колекцією (List)
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public List<string> Actors { get; set; }

        // Конструктор №1 (без параметрів)
        public Movie()
        {
            // Обов'язкова ініціалізація списку, щоб уникнути помилок
            Actors = new List<string>();
        }

        // Конструктор №2 (з параметрами для швидкого створення)
        public Movie(string title, int releaseYear, double rating, List<string> actors)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Rating = rating;
            Actors = actors;
        }

        // 3 методи для імітації поведінки об'єкта
        public void PlayMovie() { }
        public void StopMovie() { }
        public void AddReview(string reviewText) { }
    }
}