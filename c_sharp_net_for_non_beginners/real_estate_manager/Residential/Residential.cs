using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    /// <summary>
    /// Abstract class for estate type residential
    /// </summary>
    public abstract class Residential : Estate
    {
        public double ResidentialArea { get; set; }
        public int NumberOfRooms { get; set; }

        public Residential(double residentialArea, int numberOfRooms)
        {
            ResidentialArea = residentialArea;
            NumberOfRooms = numberOfRooms;
        }
    }
}