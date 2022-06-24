namespace Logeecom.AsyncProgramming.Domain
{
    public class Film
    {
        public Film()
        {
        }

        public Film(Guid id, string name, int year, string country, Guid genreId, Guid directorId, Guid awardId)
        {
            Id = id;
            Name = name;
            Year = year;
            Country = country;
            GenreId = genreId;
            DirectorId = directorId;
            AwardId = awardId;
            Actors = new();
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Year { get; private set; }

        public string Country { get; private set; }

        public Guid DirectorId { get; private set; }

        public Director Director { get; private set; }

        public List<Actor> Actors { get; private set; }

        public Guid? AwardId { get; private set; }

        public Award? Award { get; private set; }

        public Guid GenreId { get; private set; }

        public Genre Genre { get; private set; }

        public void SetActors(List<Actor> actors)
        {
            this.Actors = actors;
        }
    }
}