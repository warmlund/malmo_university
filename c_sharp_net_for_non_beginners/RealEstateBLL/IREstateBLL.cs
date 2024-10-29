using RealEstateDTO;
using System.Collections.Generic;


namespace RealEstateBLL
{
    public interface IREstateBLL
    {
        Estate CreateEstate(EstateTypes estateType, EstateParameters parameters);
        void RemoveEstate(int index);
        void AddEstate(Estate estate);
        List<Estate> GetAllEstates();
        void ReplaceEstate(Estate currentEstate, int selectedIndex);
        void CreateId(Estate estate);
        Address CreateAddress(string street, int zipCode, string city, Country country);
    }
}
