using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using System.Windows.Media.Imaging;

namespace real_estate_manager
{
    public interface IEstate
    {
        int Id { get; set; }
        EstateTypes EstateType { get; set; }
        string Address { get; set; }
        LegalForm LegalForm { get; set; }
        BitmapImage EstateImage { get; set; }

        void CreateId(List<Estate> estates);
    }
}