namespace OnlineLibrary.Models.Domain
{
    public class Book
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string[] authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public string printType { get; set; }
        public string[] categories { get; set; }
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
        public string language { get; set; }
        public string shortDescription { get; set; }
        public float averageRating { get; set; }
        public string apiBookID { get; set; }
    }
}
