using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_estate_manager
{
    public class Hospital : Institutional
    {
        private bool _hasEmergencyDepartment;
        public bool HasEmergencyDepartment { get => _hasEmergencyDepartment; set => _hasEmergencyDepartment = value; }

        public Hospital(InstitutionType institutionType, int capacity, int numberOfStaff, bool hasEmergencyDepartment) :base(institutionType, capacity, numberOfStaff)
        {
            _hasEmergencyDepartment = hasEmergencyDepartment;
        }

    }
}