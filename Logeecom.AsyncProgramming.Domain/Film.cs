namespace Logeecom.AsyncProgramming.Domain
{
    public class Film
    {
        public Film(Guid id, string name, int year, string country, Guid genreId, Guid directorId, Guid awardId)
        {
            this.Id = id;
            this.Name = name;
            this.Year = year;
            this.Country = country;
            this.GenreId = genreId;
            this.DirectorId = directorId;
            this.AwardId = awardId;
        }

        public Film(Guid id, string name, int year, string country)
        {
            Id = id;
            Name = name;
            Year = year;
            Country = country;
        }

        public Film()
        {
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

        public void AddActors(List<Actor> actors)
        {
            this.Actors = actors;
        }
    }
}