namespace FirstAPI.DTOs
{
    public class MoviesDto //use this for [post]
    {
        [MaxLength(250)]

        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        [MaxLength(2500)]
        public string Storeline { get; set; }

        public IFormFile Poster { get; set; }

        public byte GenreId { get; set; }
        //public bool isQualified => Rate > 7.5;

    }
}
