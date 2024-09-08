using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public abstract class Residential(double residentialArea, int numberOfRooms) : Estate
    {
        protected double _residentialArea = residentialArea;
        protected int _numberOfRooms = numberOfRooms;
    }
}