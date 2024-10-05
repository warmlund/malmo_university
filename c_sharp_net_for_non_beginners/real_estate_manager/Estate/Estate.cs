using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using System.Windows.Controls;

namespace real_estate_manager
{
    public abstract class Estate : IEstate
    {
        public int Id { get; set; }
        public EstateTypes EstateType { get; set; }
        public string Address { get; set; }
        public LegalForm LegalForm { get; set; }
        public Image EstateImage { get; set; }

        public virtual void CreateId()
        {
            int id = 0;
            Id = id;
        }

    }
}