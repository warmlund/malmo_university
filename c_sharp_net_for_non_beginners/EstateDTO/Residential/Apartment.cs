using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstateDTO
{
    /// <summary>
    /// Class for apartment estate types. inherits from abstract class residential
    /// </summary>
    public class Apartment : Residential
    {
        private int _floorLevel;
        private bool _hasBalcony;

        public int FloorLevel { get => _floorLevel; set => _floorLevel = value; }
        public bool HasBalcony { get => _hasBalcony; set => _hasBalcony = value; }


        public Apartment(double residentialArea, int numberOfRooms, int floorLevel, bool hasBalcony) : base(residentialArea,numberOfRooms)
        {
            _floorLevel = floorLevel;
            _hasBalcony = hasBalcony;
        }

       
    }
}