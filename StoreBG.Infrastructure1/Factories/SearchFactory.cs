using DemoShop.Infrastructure.DTOs;

namespace DemoShop.Infrastructure.Factories
{
    public static class SearchFactory
    {
        public static SearchDTO CreateBasicSearch(string term)
        {
            return new SearchDTO { SearchTerm = term, IsAdvancedSearch = false };
        }

        public static SearchDTO CreateAdvancedSearch(string term, string category)
        {
            return new SearchDTO { SearchTerm = term, IsAdvancedSearch = true, Category = category };
        }
    }
}