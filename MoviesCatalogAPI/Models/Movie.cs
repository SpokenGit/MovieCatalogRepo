namespace MoviesCatalogAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieReleaseyear { get; set; }
        public string MovieSynopsis { get; set; }
        public byte[]? MovieImage { get; set; }
        public string MovieCategory { get; set; }
        public DateTime MovieCreatedDate { get; set; }
    }
}
