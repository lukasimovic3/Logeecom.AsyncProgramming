namespace Logeecom.AsyncProgramming.Business.Dtos
{
    public class FilmDto
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public List<ActorDto> Actors { get; set; }

        public string Award { get; set; }
    }
}