using real_estate_manager.HelperClasses;
using System.Windows.Controls;

namespace real_estate_manager
{
    public interface IEstate
    {
        int Id { get; set; }
        Address Address { get; set; }
        LegalForm LegalForm { get; set; }
        Image EstateImage { get; set; }

        void UpdateEstateDetails(int id, Address address, LegalForm legalForm, Image estateImage);
    }
}