using DemoShop.Infrastructure.DTOs;

namespace DemoShop.Infrastructure.Factories
{
    public static class ProductFactory
    {
        public static ProductDTO GetExpectedBook()
        {
            return new ProductDTO { Name = "Computing and Internet", Price = 10.00m };
        }
    }
}