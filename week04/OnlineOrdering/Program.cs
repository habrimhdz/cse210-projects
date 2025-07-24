using System;
// creates at least two orders with a 2-3 products each. Call the methods to get the packing label, 
//the shipping label, and the total price of the order, and display the results of these methods.
class Program
{
    static void Main(string[] args)
    {

        Customer customer1 = new Customer("Alice Smith", new Address("123 Main St", "Springfield", "IL", "USA"));
        Customer customer2 = new Customer("Bob Johnson", new Address("Nobelio 500", "Durango", "DU", "Mexico"));


        Product productA = new Product("Laptop", 100, 799.99, 3);
        Product productB = new Product("Mouse", 200, 19.99, 2);
        Product productC = new Product("Keyboard", 300, 49.99, 1);
        Product productD = new Product("Monitor", 400, 149.99, 3);


        Order order1 = new Order(customer1);
        order1.AddProduct(productA);
        order1.AddProduct(productB);

        Order order2 = new Order(customer2);
        order2.AddProduct(productC);
        order2.AddProduct(productD);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.PackingLabelDisplay());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.ShippingLabelDisplay());
        Console.WriteLine($"Total Price: ${order1.TotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.PackingLabelDisplay());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.ShippingLabelDisplay());
        Console.WriteLine($"Total Price: ${order2.TotalCost():F2}");
    }
}