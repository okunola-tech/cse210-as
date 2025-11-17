using System.Collections.Generic;

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double subtotal = 0;

        foreach (Product p in _products)
        {
            subtotal += p.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5.0 : 35.0;

        return subtotal + shipping;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";

        foreach (Product p in _products)
        {
            label += $"{p.GetName()} (ID: {p.GetProductID()})\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddressString()}";
    }
}
