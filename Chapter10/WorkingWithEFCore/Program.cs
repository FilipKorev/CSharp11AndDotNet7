// See https://aka.ms/new-console-template for more information

using Packt.Shared;
using System.Threading.Tasks.Dataflow;

Northwind db = new Northwind();
WriteLine($"provider:{db.Database.ProviderName}");

SectionTitle("test");

//QueryingCategories();
//QueryingProducts();

//var addResult = AddProduct(categoryId: 6, "Bob's Burgers", 500M);
//var addResult = IncreaseProductPrice("Bob", 20M);

var addResult = DeleteProduct("Bob");

if (addResult == 1)
{
    Console.WriteLine($"deleted product succesfuly that starts with Bob");
}

//ListProducts(new int[] { addResult.productId });

ListProducts();
