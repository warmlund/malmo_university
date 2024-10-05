using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using System.Windows.Controls;

namespace real_estate_manager
{
    public interface IEstate
    {
        int Id { get; set; }
        EstateTypes EstateType { get; set; }
        string Address { get; set; }
        LegalForm LegalForm { get; set; }
        Image EstateImage { get; set; }

        void CreateId();
    }
}