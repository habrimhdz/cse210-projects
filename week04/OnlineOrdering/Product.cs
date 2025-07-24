using System;//No user interaction, set the values yourself.
//name, product id, price and quantity of each product. //submit a ss of the working program
//The total cost of this product is computed by multiplying the price per unit and the quantity. 
//(If the price per unit was $3 and they bought 5 of them, the product total cost would be $15.)
public class Product
{

    private string _productName;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(string productName, int productId, double price, int quantity)
    {
        _productName = productName;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double ProductCost()
    {
        double total = _price * _quantity;
        return total;
    }

    public string productName => _productName;
    public int productId => _productId;
    public double price => _price;

    public int quantity => _quantity;


   }