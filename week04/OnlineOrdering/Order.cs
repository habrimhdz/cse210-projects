using System;
//contains a list of products, customer, calculates total, and returns a string for the packing label 
//and shipping label.
//Total cost = each product plus a one time shipment cost.
//Shipping cost if customer resides in US 5usd, otherwise it's 35usd
//A packing label should list the name and product id of each product in the order.
//A shipping label should list the name and address of the customer
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

    public string PackingLabelDisplay()
    {
        string packingDisplay = "";
        foreach (Product product in _products)
        {
            packingDisplay += $"{product.productName} (ID: {product.productId})  Quantity: {product.quantity} / = {product.ProductCost()}\n";
        }
        return packingDisplay;
    }

    public string ShippingLabelDisplay()
    {
        string shippingDisplay = $"{_customer.GetCustomerName()} \n{_customer.GetCustomerAddress().FullAddress()}";
        return shippingDisplay;

    }

    public double TotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.ProductCost();
        }

        // Shipping cost
        int shippingCost = _customer.LivesInUsa() ? 5 : 35;
        total += shippingCost;

        return total;
    }



}