using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public class Villa : Residential
    {
        private double _gardenSize;

        public Villa(double residentialArea, int numberOfRooms, double gardenSize):base(residentialArea, numberOfRooms)
        {
            _gardenSize = gardenSize;
        }
    }
}