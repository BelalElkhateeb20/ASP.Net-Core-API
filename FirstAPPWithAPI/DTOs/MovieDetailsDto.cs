namespace FirstAPI.DTOs
{
    using FirstAPPWithAPI.Data.Models;

    public class MovieDetailsDto//,[Put]
    {

        [MaxLength(250)]

        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        [MaxLength(2500)]
        public string Storeline { get; set; }
        public IFormFile Poster { get; set; }
    }
}
