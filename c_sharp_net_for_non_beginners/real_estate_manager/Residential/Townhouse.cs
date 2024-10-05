using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public class Townhouse : Villa
    {
        private bool _isDetached;
        public bool IsDetached { get => _isDetached; set => _isDetached = value; }

        public Townhouse(double residentialArea, int numberOfRooms, double gardenSize, bool isDetached) : base(residentialArea,numberOfRooms,gardenSize)
        {
            IsDetached = isDetached;
        }
    }
}