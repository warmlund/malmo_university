using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public class Tenement : Apartment
    {
        private double _salesValue;

        public Tenement(double residentialArea, int numberOfRooms, int floorLevel, bool hasBalcony, double salesValue) : base(residentialArea,numberOfRooms,floorLevel,hasBalcony)
        {
            _salesValue = salesValue;
        }
    }
}