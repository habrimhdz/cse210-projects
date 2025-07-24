using System;
//The address contains a string for the street address, the city, state/province, and country.
//The address should have a method that can return whether it is in the USA or not.
//The address should have a method to return a string all of its fields together in one string 
//(with newline characters where appropriate)
public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;

    }

    public bool UsaOrNot(string country)
    {
        return country == "USA";
    }

    public string FullAddress()
    {
        string singleAddress = $"{_street}\n{_city}, {_stateProvince}\n{_country}";
        return singleAddress;
    }

    public string Country => _country;
}

