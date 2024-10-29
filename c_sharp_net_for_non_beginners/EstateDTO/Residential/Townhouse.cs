using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDTO
{
    /// <summary>
    /// Class for estate type townhouse. inherits villa
    /// </summary>
    public class Townhouse : Villa
    {
        private bool _isDetached;

        [JsonProperty("IsDetached")]
        public bool IsDetached { get => _isDetached; set => _isDetached = value; }

        public Townhouse(double residentialArea, int numberOfRooms, double gardenSize, bool isDetached) : base(residentialArea, numberOfRooms, gardenSize)
        {
            IsDetached = isDetached;
        }
    }
}