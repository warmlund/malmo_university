﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDTO
{
    /// <summary>
    /// Class for tenement aparments. inherits apartment
    /// </summary>
    public class Tenement : Apartment
    {
        private double _salesValue;

        [JsonProperty("SalesValue")]
        public double SalesValue { get => _salesValue; set => _salesValue = value; }

        public Tenement(double residentialArea, int numberOfRooms, int floorLevel, bool hasBalcony, double salesValue) : base(residentialArea, numberOfRooms, floorLevel, hasBalcony)
        {
            SalesValue = salesValue;
        }

    }
}