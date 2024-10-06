using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using System.Windows.Media.Imaging;

namespace real_estate_manager
{
    /// <summary>
    /// Interface for estate objects
    /// </summary>
    public interface IEstate
    {
        int Id { get; set; }
        EstateTypes EstateType { get; set; }
        Address EstateAddress { get; set; }
        LegalForm LegalForm { get; set; }
        BitmapImage EstateImage { get; set; }

        void CreateId(List<Estate> estates);
    }
}