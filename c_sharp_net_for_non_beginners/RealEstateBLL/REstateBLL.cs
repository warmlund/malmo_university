using EstateDTO;
using EstateDTO.Enum;
using EstateDTO.HelperClasses;
using RealEstateBLL.ListManager;
using System;
using System.Collections.Generic;

namespace RealEstateBLL
{
    public class REstateBLL : IREstateBLL
    {
        EstateManager _esstateManager;
        public REstateBLL()
        {
            _esstateManager = new EstateManager();
        }

        public Estate CreateEstate(EstateTypes estateType, EstateParameters parameters)
        {
            return estateType switch
            {
                EstateTypes.Villa => new Villa(parameters.ResidentialArea, parameters.NumberOfRooms, parameters.GardenSize),
                EstateTypes.Townhouse => new Townhouse(parameters.ResidentialArea, parameters.NumberOfRooms, parameters.GardenSize, parameters.IsDetached),
                EstateTypes.Apartment => CreateApartment(parameters),
                EstateTypes.Hotel => new Hotel(parameters.PropertySize, parameters.NumberOfHotelRooms),
                EstateTypes.Shop => new Shop(parameters.PropertySize, parameters.RetailArea),
                EstateTypes.Warehouse => new Warehouse(parameters.PropertySize, parameters.StorageArea),
                EstateTypes.Factory => new Factory(parameters.PropertySize, parameters.SelectedFactoryType),
                EstateTypes.Hospital => new Hospital(parameters.SelectedInstitutionType, parameters.NumberOfStaff, parameters.HasEmergencyDept),
                EstateTypes.School => new School(parameters.SelectedInstitutionType, parameters.NumberOfStaff, parameters.SelectedSchoolType),
                EstateTypes.University => new University(parameters.SelectedInstitutionType, parameters.NumberOfStaff, parameters.NumberOfFacs),
                _ => throw new ArgumentException("Invalid estate type")
            };
        }
        private Estate CreateApartment(EstateParameters parameters)
        {
            return parameters.SelectedLegalForm switch
            {
                LegalForm.Rental => new Rental(parameters.ResidentialArea, parameters.NumberOfRooms, parameters.FloorLevel, parameters.HasBalcony, parameters.Rent),
                LegalForm.Tenement => new Tenement(parameters.ResidentialArea, parameters.NumberOfRooms, parameters.FloorLevel, parameters.HasBalcony, parameters.SalesValue),
                _ => new Apartment(parameters.ResidentialArea, parameters.NumberOfRooms, parameters.FloorLevel, parameters.HasBalcony)
            };
        }


        public void AddEstate(Estate estate)
        {
            _esstateManager.Add(estate);
        }

        public List<Estate> GetAllEstates()
        {
            return _esstateManager.GetAllEStates();
        }

        public void RemoveEstate(int index)
        {
            _esstateManager.RemoveAt(index);
        }

        public void ReplaceEstate(Estate currentEstate, int selectedIndex)
        {
            _esstateManager.ReplaceAt(currentEstate, selectedIndex);
        }


        /// <summary>
        /// A method for creating a unique Id 
        /// </summary>
        public void CreateId(Estate estate)
        {
            if (_esstateManager == null || _esstateManager.Count == 0)
            {
                estate.Id = 1;
                return;
            }

            HashSet<int> existingIds = new HashSet<int>(_esstateManager.GetIds());

            int newId = 1;

            while (existingIds.Contains(newId))
            {
                newId++;
            }

            estate.Id = newId;
        }

    }
}
