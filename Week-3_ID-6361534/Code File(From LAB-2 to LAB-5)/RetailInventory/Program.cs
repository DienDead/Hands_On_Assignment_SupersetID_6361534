using Microsoft.EntityFrameworkCore;
using RetailInventory;
using RetailInventory.Models;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Create categories
        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        await context.Categories.AddRangeAsync(electronics, groceries);

        // Create products
        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

        await context.Products.AddRangeAsync(product1, product2);

        // Save all changes to the database
        await context.SaveChangesAsync();

        Console.WriteLine("Data inserted successfully!");

        // 1. Retrieve all products
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        // 2. Find product by ID
        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"Found: {product?.Name}");

        // 3. Find first product with price > ₹50,000
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name}");
    }
}