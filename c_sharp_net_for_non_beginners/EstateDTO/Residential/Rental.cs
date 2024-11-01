﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDTO
{
    /// <summary>
    /// class for rental apartments, inherits from apartment class
    /// </summary>
    public class Rental : Apartment
    {

        [JsonProperty("Rent")]
        public double Rent { get; set; }

        public Rental(double residentialArea, int numberOfRooms, int floorLevel, bool hasBalcony, double rent) : base(residentialArea, numberOfRooms, floorLevel, hasBalcony)
        {
            Rent = rent;
        }

    }
}