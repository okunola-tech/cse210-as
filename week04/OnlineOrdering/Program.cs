using System;

class Program
{
    static void Main(string[] args)
    {
        //---------------------------
        // Order 1 (USA Customer)
        //---------------------------
        Address addr1 = new Address("123 Maple St", "Dallas", "TX", "USA");
        Customer cust1 = new Customer("Emily Carter", addr1);
        Order order1 = new Order(cust1);

        order1.AddProduct(new Product("Notebook", "N100", 3.50, 5));
        order1.AddProduct(new Product("Pen Pack", "P210", 2.25, 3));
        order1.AddProduct(new Product("Stapler", "S050", 6.75, 1));

        //---------------------------
        // Order 2 (International Customer)
        //---------------------------
        Address addr2 = new Address("45 Elm Road", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Mark Peterson", addr2);
        Order order2 = new Order(cust2);

        order2.AddProduct(new Product("Laptop Stand", "LS300", 25.00, 1));
        order2.AddProduct(new Product("USB Cable", "UC220", 7.99, 2));

        //---------------------------
        // Display Results
        //---------------------------
        Console.WriteLine("----- ORDER 1 -----");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}");
        Console.WriteLine();

        Console.WriteLine("----- ORDER 2 -----");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}");
    }
}
