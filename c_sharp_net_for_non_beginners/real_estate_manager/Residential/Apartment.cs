using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public class Apartment : Residential
    {
        private int _floorLevel;
        private bool _hasBalcony;

        public Apartment(double residentialArea, int numberOfRooms, int floorLevel, bool hasBalcony) : base(residentialArea,numberOfRooms)
        {
            _floorLevel = floorLevel;
            _hasBalcony = hasBalcony;
        }
    }
}