﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    /// <summary>
    /// Abstract class for commercial estates
    /// </summary>
    public abstract class Commercial : Estate
    {
        private double propertySize;
        public double PropertySize { get => propertySize; set => propertySize = value; }

        public Commercial(double propertySize)
        {
            this.propertySize = propertySize;
        }       
    }
}