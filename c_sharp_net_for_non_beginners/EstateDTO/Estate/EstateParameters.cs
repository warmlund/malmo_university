using EstateDTO.Enum;
using EstateDTO.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateDTO
{
    public class EstateParameters
    {
        public double ResidentialArea { get; set; }
        public int NumberOfRooms { get; set; }
        public double GardenSize { get; set; }
        public bool IsDetached { get; set; }
        public double PropertySize { get; set; }
        public int NumberOfHotelRooms { get; set; }
        public double RetailArea { get; set; }
        public double StorageArea { get; set; }
        public FactoryType SelectedFactoryType { get; set; }
        public InstitutionType SelectedInstitutionType { get; set; }
        public int NumberOfStaff { get; set; }
        public bool HasEmergencyDept { get; set; }
        public SchoolType SelectedSchoolType { get; set; }
        public int NumberOfFacs { get; set; }
        public LegalForm SelectedLegalForm { get; set; }
        public int FloorLevel { get; set; }
        public bool HasBalcony { get; set; }
        public double Rent { get; set; }
        public double SalesValue { get; set; }
    }
}
