using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public abstract class Commercial : Estate
    {
        private double propertySize;
        protected double PropertySize { get => propertySize; set => propertySize = value; }

        public Commercial(double propertySize)
        {
            propertySize = propertySize;
        }

       
    }
}