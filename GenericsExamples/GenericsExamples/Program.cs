using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ListOfNumbers
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            // ListOfStrings
            List<string> strings = new List<string>();

            // ListOfProducts
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Test 1",
                },
                new Product
                {
                    Id = 2,
                    Name = "Test 2",
                }
            };

            // Product list using objects - Fragile!!
            object[,] productListingMatrix = new object[2, 2]
            {
                { "test", "Product 1" },
                { 2, "Product 2" }
            };

            // int id1 = (int)productListingMatrix[0, 0];

            // Product list using tuples
            Tuple<int, string>[] productListing = new[]
            {
                new Tuple<int, string>
                {
                    Item1 = 1,
                    Item2 = "Product 1"
                },
                new Tuple<int, string>
                {
                    Item1 = 2,
                    Item2 = "Product 2"
                }
            };

            int id2 = productListing[0].Item1;

            // Person listing (Id, PersonName, DateOfBirth)
            Tuple<int, string, DateTime>[] personsListing = new[]
            {
                new Tuple<int, string, DateTime>
                {
                    Item1 = 1,
                    Item2 = "John Doe",
                    Item3 = new DateTime(1990, 05, 09)
                }
            };

            for (int i = 0; i < personsListing.Length; i++)
            {
                //personsListing[0].
            }

            DataTable dt = new DataTable("Table1");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            int col1 = 1;
            string col2 = "John Doe";
            // dt.Rows.Add(col1, col2, null);

            int var1 = 10;
            int var2 = 20;
            Console.WriteLine(var1);
            Console.WriteLine(var2);
            VariableHelper.Swap(ref var1, ref var2);
            Console.WriteLine(var1);
            Console.WriteLine(var2);

            string str1 = "Test 1";
            string str2 = "Test 2";
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            VariableHelper.Swap<string>(ref str1, ref str2);
            Console.WriteLine(str1);
            Console.WriteLine(str2);

            List<Person> personsList = new List<Person>
            {
                new Person
                {
                    Name = "John Doe",
                    Cnp = "1234",
                    DateOfBirth = new DateTime(1990, 5, 9)
                },
                new Person
                {
                    Name = "John Doe jr.",
                    Cnp = "4567",
                    DateOfBirth = new DateTime(1990, 5, 9),
                    ParentCnp = "1234"
                }
            };

            Dictionary<string, Person> indexByCnp = new Dictionary<string, Person>();
            foreach (Person person in personsList)
            {
                indexByCnp[person.Cnp] = person;
            }


            // O(1) = constant, regardless of number of elements
            // O(n) = dp. with number of elements
            // O(n^2) = dp. 
            foreach (Person p in  personsList)
            {
                Console.WriteLine($"Person: {p.Name}, date-of-birth: {p.DateOfBirth:yyyy-MM-dd}");

                // find p's parent
                if (!string.IsNullOrEmpty(p.ParentCnp) &&
                    indexByCnp.TryGetValue(p.ParentCnp, out Person parent))
                {
                    // we found the parent
                    Console.WriteLine($"Child of: {parent.Name}");
                }
            }

            

            Product prod1 = new Product
            {
                Id = 1,
                Name = "Pizza"
            };

            Product prod2 = new Product
            {
                Id = 1,
                Name = "Pizza"
            };

            PricedProduct prod3 = new PricedProduct
            {
                Id = 2,
                Name = "Hidroizolatie",
                Price = 150M
            };

            // OOP: ChildClass => ParentClass
            Product prod4 = prod3;
            IEquatable<Product> equatableTest = prod1;
            
            // Generics invariance
            IEnumerable<PricedProduct> list1 = new List<PricedProduct> { prod3 };
            // if PricedProduct => Product
            // List<PricedProduct> => List<Product>
            IEnumerable<Product> listBase = list1;

            // (similar to OOP behavior): out
            // Covariance: Generic<ChildClass> => Generic<BaseClass>, where ChildClass: BaseClass
            // (against* OOP behavior): in
            // Contravariance: Generic<BaseClass> => Generic<ChildClass>, where ChildClass: BaseClass

            IPrinter<Product> productPrinter = new ProductPrinter();
            // IPrinter<Product> => IPrinter<PricedProduct>
            IPrinter<PricedProduct> procedProductPrinter = productPrinter;
            procedProductPrinter.Print(prod3);

            bool areEqual = prod1 == prod2;
            Console.WriteLine($"prod1 == prod2? {areEqual}");

            Product prod = ObjectFactory.Create<Product>();

            Console.ReadKey();
        }
    }
}
