using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstateDTO
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