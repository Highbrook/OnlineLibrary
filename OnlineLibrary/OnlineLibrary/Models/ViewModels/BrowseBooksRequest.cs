using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.ViewModels
{
    public class BrowseBooksRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string PublishedDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public string PrintType { get; set; }
        [Required]
        public string[] Categories { get; set; }
        [Required]
        public string AverageRating { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public float ListPrice { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string BuyLink { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}
