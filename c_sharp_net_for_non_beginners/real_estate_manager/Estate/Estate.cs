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

        public virtual void CreateId(List<Estate> estates)
        {
            if (estates == null || estates.Count == 0)
            {
                Id = 1;
                return;
            }

            HashSet<int> existingIds = new HashSet<int>(estates.Select(e => e.Id));

            int newId = 1;

            while (existingIds.Contains(newId))
            {
                newId++;
            }

            Id = newId;
        }



    }
}