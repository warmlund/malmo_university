using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDTO
{
    /// <summary>
    /// A class for storing the address of an event
    /// </summary>
    public class Address
    {
        private string _street;
        private string _city;
        private Country _country;
        private int _zipcode;

        public string Street { get => _street; set => _street = value; }
        public string City { get => _city; set => _city = value; }
        public Country Country { get => _country; set => _country = value; }
        public int Zipcode { get => _zipcode; set => _zipcode = value; }

        public Address(string street, int zipcode, string city, Country country)
        {
            _street = street;
            _city = city;
            _country = country;
            _zipcode = zipcode;
        }
    }
}