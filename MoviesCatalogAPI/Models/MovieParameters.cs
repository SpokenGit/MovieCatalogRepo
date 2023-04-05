namespace MoviesCatalogAPI.Models
{
    public class MovieParameters : QueryStringParameters
    {
        public MovieParameters() 
        {
            OrderBy = "MovieReleaseyear";
        }
        public string Category { get; set; } = string.Empty;
        public string Yearrelease { get; set; } = string.Empty;
        public string Searchby { get; set; } = string.Empty;
    }
}
