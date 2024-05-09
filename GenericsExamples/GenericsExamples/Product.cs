using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace GenericsExamples
{
    public class Product : IEquatable<Product>
    {
        public Product()
        {
            Id = 0;
            Name = string.Empty;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Equals(Product other)
        {
            if (other is null)
            {
                return false;
            }

            return this.Id == other.Id &&
                   string.Equals(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        // this needs to be done
        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        // this needs to be done
        public override int GetHashCode()

        public static bool operator == (Product obj1, Product obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Product obj1, Product obj2)
        {
            return !obj1.Equals(obj2);
        }
    }

    public class PricedProduct : Product
    {
        public decimal Price { get; set; }
    }

    // IPrinter<Product> => IPrinter<PricedProduct>
    // Print(Product) => Print(PricedProduct)

    public interface IPrinter<in T>
    {
        void Print(T obj);
    }

    public class ProductPrinter : IPrinter<Product>
    {
        public void Print(Product obj)
        {
            Console.WriteLine($"#{obj.Id} - {obj.Name}");
        }
    }
}
