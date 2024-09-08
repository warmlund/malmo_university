using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public abstract class Commercial(double propertySize) : Estate
    {
        protected double _propertySize = propertySize;
    }
}