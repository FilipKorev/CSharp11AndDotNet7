
using Microsoft.EntityFrameworkCore;
using Packt.Shared;

partial class Program
{
    static void QueryingCategories()
    {
        using (Northwind db = new Northwind())
        {
            SectionTitle("Categproes and how many products they have");

            IQueryable<Category> categories = db.Categories?
                .Include(c => c.Products);

            if((categories is null) || (!categories.Any()))
                {
                Fail("no categories found!");
                return;
            }

            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.CategoryName} has {category.Products.Count} products");
                Console.WriteLine("They are:");
                foreach (var product in category.Products)
                {
                    Console.WriteLine($" * {product.ProductName}");
                }
            }
        }
    }

    static void QueryingProducts()
    {
        using (Northwind db = new Northwind())
        {
            SectionTitle("Product name and their category name");

            IQueryable<Product> products = db.Products?.Include(p => p.Category);

            if ((products is null) || (!products.Any()))
            {
                Fail("no products found!");
                return;
            }

            foreach (Product p in products)
            {
                Console.WriteLine($"{p.ProductName} is in {p.Category.CategoryName} category");
            }
        }

    }
}
