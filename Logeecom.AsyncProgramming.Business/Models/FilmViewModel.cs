namespace Logeecom.AsyncProgramming.Business.Models
{
    public class FilmViewModel
    {
        public FilmViewModel()
        {
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }

        public List<ActorViewModel> Actors { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public string Award { get; set; }
    }
}