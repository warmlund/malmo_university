using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RealEstateDTO;

namespace RealEstateDTO
{
    /// <summary>
    /// Abstract class for commercial estates
    /// </summary>
    public abstract class Commercial : Estate
    {
        private double propertySize;

        [JsonProperty("PropertySize")]
        public double PropertySize { get => propertySize; set => propertySize = value; }

        public Commercial(double propertySize)
        {
            this.propertySize = propertySize;
        }
    }
}