namespace DemoShop.Infrastructure.DTOs
{
    public class SearchDTO
    {
        public string SearchTerm { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string Category { get; set; }
    }
}