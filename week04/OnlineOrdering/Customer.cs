using System;
// Customer's name and adress (name is a string, adress is a class)
//A method that returns if they live in the us on the address)
public class Customer
{
    private string _customerName;
    private Address _address;

    public Customer(string customerName, Address address)
    {
        _customerName = customerName;
        _address = address;
    }

    public bool LivesInUsa()
    {
        return _address.UsaOrNot(_address.Country);
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public Address GetCustomerAddress()
    {
        return _address;
    }
}