using System;
using System.Collections.Generic;
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class Cart
{
   public List<Product> products=new List<Product>();


    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine($"Added {product.Name} to cart.");
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price;
        }
        return total;
    }
}
public class CartPrinter
{
    private Cart cart;
    public CartPrinter(Cart cart)
    {
        this.cart = cart;
    }
    public void PrintCart()
    {
        Console.WriteLine("Cart Contents:");
        foreach (var product in cart.products)
        {
            Console.WriteLine($"{product.Name} - ${product.Price}");
        }
        Console.WriteLine($"Total: ${cart.CalculateTotal()}");
    }
}



public class SingleResponsibility
{
    public static void Main(string[] args)
    {
        Cart cart = new Cart();
        cart.AddProduct(new Product("Laptop", 999.99m));
        cart.AddProduct(new Product("Mouse", 49.99m));

        CartPrinter printer = new CartPrinter(cart);
        printer.PrintCart();
        
    }
}