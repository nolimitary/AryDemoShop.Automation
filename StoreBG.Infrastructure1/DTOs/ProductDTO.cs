using System;

namespace DemoShop.Infrastructure.DTOs
{
    public class ProductDTO : IEquatable<ProductDTO>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool Equals(ProductDTO other)
        {
            if (other == null) return false;
            return Name == other.Name && Price == other.Price;
        }
    }
}