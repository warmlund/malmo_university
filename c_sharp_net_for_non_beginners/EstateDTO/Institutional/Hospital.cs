using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDTO
{
    /// <summary>
    /// Hospital estate class inheriting from the commercial abstract class
    /// </summary>
    /// 
    public class Hospital : Institutional
    {
        private bool _hasEmergencyDepartment;

        [JsonProperty("HasEmergencyDepartment")]
        public bool HasEmergencyDepartment { get => _hasEmergencyDepartment; set => _hasEmergencyDepartment = value; }

        public Hospital(InstitutionType institutionType, int numberOfStaff, bool hasEmergencyDepartment) : base(institutionType, numberOfStaff)
        {
            _hasEmergencyDepartment = hasEmergencyDepartment;
        }

    }
}