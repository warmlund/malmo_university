using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    /// <summary>
    /// class for rental apartments, inherits from apartment class
    /// </summary>
    public class Rental : Apartment
    {
        public double Rent { get; set; }

        public Rental(double residentialArea, int numberOfRooms, int floorLevel, bool hasBalcony,double rent): base(residentialArea, numberOfRooms, floorLevel, hasBalcony)
        {
            Rent = rent;
        }

    }
}