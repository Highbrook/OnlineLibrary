using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.ViewModels
{
    public class BrowseBooksRequest
    {
        [Required]
        public string SearchQuery { get; set; }
    }
}
