using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDTO
{
    /// <summary>
    /// Abstract class for estate type residential
    /// </summary>
    public abstract class Residential : Estate
    {
        [JsonProperty("ResidentialArea")]
        public double ResidentialArea { get; set; }

        [JsonProperty("NumberOfRooms")]
        public int NumberOfRooms { get; set; }

        public Residential(double residentialArea, int numberOfRooms)
        {
            ResidentialArea = residentialArea;
            NumberOfRooms = numberOfRooms;
        }
    }
}