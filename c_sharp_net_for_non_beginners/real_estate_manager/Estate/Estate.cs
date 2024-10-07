using real_estate_manager.Enum;
using real_estate_manager.HelperClasses;
using real_estate_manager.ListManager;
using System.Windows.Media.Imaging;

namespace real_estate_manager
{
    /// <summary>
    /// Abstract class for estate objects inheriting from the interface
    /// </summary>
    public abstract class Estate : IEstate
    {
        public int Id { get; set; }
        public EstateTypes EstateType { get; set; }
        public Address EstateAddress { get; set; }
        public LegalForm LegalForm { get; set; }
        public BitmapImage EstateImage { get; set; }

        /// <summary>
        /// A method for creating a unique Id 
        /// </summary>
        public virtual void CreateId(EstateManager estates)
        {
            if (estates == null || estates.Count == 0)
            {
                Id = 1;
                return;
            }

            HashSet<int> existingIds = new HashSet<int>(estates.GetIds());

            int newId = 1;

            while (existingIds.Contains(newId))
            {
                newId++;
            }

            Id = newId;
        }



    }
}