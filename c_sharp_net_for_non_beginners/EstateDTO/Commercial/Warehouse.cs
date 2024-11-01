﻿using Newtonsoft.Json;

namespace RealEstateDTO
{
    /// <summary>
    /// Warehouse estate class inheriting from the commercial abstract class
    /// </summary>
    public class Warehouse : Commercial
    {
        private double _storageArea;

        [JsonProperty("StorageArea")]
        public double StorageArea { get => _storageArea; set => _storageArea = value; }

        public Warehouse(double propertySize, double storageArea) : base(propertySize)
        {
            _storageArea = storageArea;
        }

    }
}