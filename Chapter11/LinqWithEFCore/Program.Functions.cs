
using LinqWithEFCore;
using Microsoft.EntityFrameworkCore;

partial class Program
{
    static void FilterAndSort()
    {
        SectionTitle("Filter and Sort");

        using(Northwind db =  new Northwind())
        {
            DbSet<Product> allProducts = db.Products;

            IQueryable<Product> filterProducts = allProducts.Where(p => p.UnitPrice < 10M);

            IQueryable<Product> sortAndFilterProducts = filterProducts.OrderByDescending(p => p.UnitPrice);
            
            foreach(Product p in sortAndFilterProducts) 
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00}",p.ProductId, p.ProductName, p.UnitPrice);
            }

            Console.WriteLine(sortAndFilterProducts.ToQueryString());
        }
    }


    static void FilterAndSortQuerry()
    {
        SectionTitle("FIlter and sort - querry");
        using(Northwind db = new Northwind())
        {
            IQueryable<Product> products = 
                from product in db.Products 
                where product.UnitPrice < 10M 
                orderby product.UnitPrice descending
                select product;

            foreach (Product p in products)
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
            }

            Console.WriteLine(products.ToQueryString());
        }
    }
}

