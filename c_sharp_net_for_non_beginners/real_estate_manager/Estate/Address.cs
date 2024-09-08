using real_estate_manager.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public class Address
    {
        private string _street;
        private string _city;
        private Country _country;
        private int _zipcode;

        public Address(string street, int zipcode, string city, Country country)
        {
            this._street = street;
            this._city = city;
            this._country = country;
            this._zipcode = zipcode;
        }

    }
}