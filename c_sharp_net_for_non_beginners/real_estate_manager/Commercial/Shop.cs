using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public class Shop : Commercial
    {
        private double _retailArea;

        public Shop(double propertySize, double retailArea) :base(propertySize)
        {
            _retailArea = retailArea;
        }
    }
}