﻿using Newtonsoft.Json;

namespace RealEstateDTO
{
    /// <summary>
    /// School estate class inheriting from the commercial abstract class
    /// </summary>
    /// 
    public class School : Institutional
    {
        private SchoolType _type;

        [JsonProperty("Type")]
        public SchoolType Type { get => _type; set => _type = value; }
        public School(InstitutionType institutionType, int numberOfStaff, SchoolType schoolType) : base(institutionType, numberOfStaff)
        {
            _type = schoolType;
        }
    }
}